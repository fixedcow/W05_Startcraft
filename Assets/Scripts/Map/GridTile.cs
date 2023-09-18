using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
	#region PublicVariables
	public Player Owner { get { return owner; } }
	#endregion

	#region PrivateVariables
	private Player owner;
	private SpriteRenderer sr;
	#endregion

	#region PublicMethod
	public void SetOwner(Player _owner)
	{
		owner = _owner;
	}
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
	private void OnTriggerEnter2D(Collider2D _collision)
	{
		Unit unit;
		if (_collision.TryGetComponent(out unit) == true && unit.Owner != owner)
		{
			if(owner != null)
			{
				owner.RemoveTile(this);
			}
			owner = unit.Owner;
			owner.AddTile(this);
		}
	}
	#endregion
}
