using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

public class Path : MonoBehaviour
{
	#region PublicVariables
	public IReadOnlyList<GridTile> Tiles { get { return tiles.AsReadOnly(); } }
	#endregion

	#region PrivateVariables
	[SerializeField] private List<GridTile> tiles = new List<GridTile>();
	#endregion

	#region PublicMethod
	public Path GetThisPath()
	{
		return this;
	}
	#endregion

	#region PrivateMethod
	private void OnMouseDown()
	{
		GameManager.instance.Player.SetPath(this);
		EffectManager.instance.HighlightSelectedPath(transform.position);
	}
	#endregion
}
