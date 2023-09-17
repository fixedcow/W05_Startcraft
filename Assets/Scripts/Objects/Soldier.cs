using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Unit
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private float moveSpeed;
	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	private void Update()
	{
		transform.Translate(transform.right * moveSpeed * Time.deltaTime);
	}

	protected override void CollideWithEnemy()
	{
		base.CollideWithEnemy();
		EffectManager.instance.InstantiateBurstEffect(transform.position);
		gameObject.SetActive(false);
	}
	#endregion
}
