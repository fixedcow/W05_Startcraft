using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	#region PublicVariables
	[ShowInInspector] public Color32 MainColor { get; private set; }
	[ShowInInspector] public Color32 SubColor { get; private set; }
	#endregion

	#region PrivateVariables
	[SerializeField] private List<GridTile> tiles = new List<GridTile>();
	#endregion

	#region PublicMethod
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
	#endregion
}
