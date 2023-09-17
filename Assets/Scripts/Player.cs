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
	[SerializeField] private CommandCenter commandCenter;
	[SerializeField] private List<Camp> camps;
	[SerializeField] private List<GridTile> tiles = new List<GridTile>();
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		commandCenter.Initialize(this);
		foreach(var camp in camps)
		{
			camp.Initialize(this);
		}
	}
	public void AddTile(GridTile _tile)
	{
		_tile.SetColor(MainColor);
		tiles.Add(_tile);
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
	}
	#endregion

	#region PrivateMethod
	private void Start()
	{
		Initialize();
	}
	#endregion
}
