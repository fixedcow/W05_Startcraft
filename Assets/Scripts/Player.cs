using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region PublicVariables
	[ShowInInspector] public Color32 MainColor;
	[ShowInInspector] public Color32 SubColor;
	#endregion

	#region PrivateVariables
	[SerializeField] private UIScore uiScore;
	[SerializeField] private UIGold uiGold;
	[SerializeField] private CommandCenter commandCenter;
	[SerializeField] private List<Camp> camps;
	[SerializeField] private List<GridTile> tiles = new List<GridTile>();
	[SerializeField] private List<UnitProvider> providers = new List<UnitProvider>();
	private int gold;
	private float totalProductivity;
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
	public void UpdateTotalProductivity()
	{

	}
	#endregion

	#region PrivateMethod
	private void Start()
	{
		Initialize();
	}
	private void Update()
	{
		
	}
	#endregion
}
