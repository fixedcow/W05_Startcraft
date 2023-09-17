using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private SpriteRenderer sr;
	#endregion

	#region PublicMethod
	public void SetColor(Color32 _color)
	{
		sr.DOColor(_color, 1f);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		TryGetComponent(out sr);
	}
	#endregion
}
