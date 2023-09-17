using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Sirenix.OdinInspector;

public abstract class Unit : MonoBehaviour
{
	#region PublicVariables
	public Player Owner { get { return owner; } }
	public int Hp { get { return hp; } }
	#endregion

	#region PrivateVariables
	protected Player owner;
	protected GameObject rend;
	protected SpriteRenderer fill;
	protected int hp;
	#endregion

	#region PublicMethod
	[Button]
	public virtual void Initialize(Player _owner)
	{
		owner = _owner;
		transform.rotation = owner.transform.rotation;
		fill.color = owner.MainColor;
	}
	#endregion

	#region PrivateMethod
	protected virtual void Awake()
	{
		transform.Find("Renderer").TryGetComponent(out rend);
		transform.Find("Renderer/Fill").TryGetComponent(out fill);
	}
	private void OnTriggerEnter2D(Collider2D _collision)
	{
		Unit unit;
		if (_collision.TryGetComponent(out unit) == true && unit.owner != owner)
		{
			unit.CollideWithEnemy();
		}
	}
	protected abstract void CollideWithEnemy();
	#endregion
}
