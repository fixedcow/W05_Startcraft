using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

public class Camp : Unit
{
	#region PublicVariables
	public int Hp { get { return hp; } }
	#endregion

	#region PrivateVariables
	protected TextMeshPro hpText;

	[SerializeField] protected int hp;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	protected override void Awake()
	{
		base.Awake();
		transform.Find("Hp Text").TryGetComponent(out hpText);
	}
	public override void Initialize(Player _owner)
	{
		base.Initialize(_owner);
		hpText.transform.localRotation = Quaternion.Euler(-owner.transform.eulerAngles);
		UpdateHp();
	}
	protected void UpdateHp()
	{
		hpText.text = hp.ToString();
	}
	protected override void CollideWithEnemy()
	{
		--hp;
		UpdateHp();
		if (hp <= 0)
		{
			EffectManager.instance.InstantiateBurstEffect(transform.position);
			gameObject.SetActive(false);
		}
	}
	#endregion
}
