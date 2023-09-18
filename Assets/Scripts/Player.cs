using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region PublicVariables
	[ShowInInspector] public Color32 MainColor;
	[ShowInInspector] public Color32 SubColor;
	public int Gold { get { return gold; } }
	#endregion

	#region PrivateVariables
	[SerializeField] private UIScore uiScore;
	[SerializeField] private UIGold uiGold;
	[SerializeField] private CommandCenter commandCenter;
	[SerializeField] private List<Camp> camps;
	[SerializeField] private List<GridTile> tiles = new List<GridTile>();
	[SerializeField] private List<UnitProvider> providers = new List<UnitProvider>();
	[SerializeField]private bool isPlayer;
	private int gold;
	[ReadOnly] [ShowInInspector] private float totalProductivity;
	private float producePower = 0f;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		commandCenter.Initialize(this);
		foreach(var camp in camps)
		{
			camp.Initialize(this);
		}
		foreach(var tile in tiles)
		{
			tile.SetOwner(this);
		}
		foreach (var provider in providers)
		{
			provider.SetOwner(this);
		}
		uiScore.UpdateScore(tiles.Count);
	}
	[Button]
	public void SpawnSoldier()
	{
		commandCenter.SpawnUnit();
	}
	public void AddTile(GridTile _tile)
	{
		_tile.SetColor(SubColor);
		tiles.Add(_tile);
		uiScore.UpdateScore(tiles.Count);
	}
	public void RemoveTile(GridTile _tile)
	{
		foreach(GridTile tile in tiles)
		{
			if(tile == _tile)
			{
				tiles.Remove(tile);
				break;
			}
		}
		uiScore.UpdateScore(tiles.Count);
	}
	public void SetPath(Path _path)
	{
		commandCenter.SetPath(_path);
	}
	public void ProvideGold()
	{
		gold += tiles.Count;
		if(uiGold != null)
			uiGold.UpdateGold(gold);
	}
	/// <summary>
	/// 골드가 충분하다면 true반환. 부족하다면 false.
	/// </summary>
	/// <param name="amount"></param>
	public bool RemoveGold(int amount)
	{
		if(gold >= amount)
		{
			gold -= amount;
			uiGold.UpdateGold(gold);
			return true;
		}
		else
		{
			return false;
		}
	}
	#endregion

	#region PrivateMethod
	private void Start()
	{
		Initialize();
		if(isPlayer)
		{
			UIProductivity.instance.SetProviders(providers);
		}
	}
	private void Update()
	{
		UpdateTotalProductivity();
		CheckProducePowerToSpawn();
	}
	private void UpdateTotalProductivity()
	{
		totalProductivity = 0;
		for (int i = 0; i < providers.Count; ++i)
		{
			totalProductivity += providers[i].Productivity;
		}
		if (isPlayer)
		{
			UIProductivity.instance.UpdateProductivity();
		}
	}
	private void CheckProducePowerToSpawn()
	{
		producePower += totalProductivity * Time.deltaTime;
		if(producePower > 10)
		{
			producePower = 0f;
			SpawnSoldier();
		}
	}
	#endregion
}
