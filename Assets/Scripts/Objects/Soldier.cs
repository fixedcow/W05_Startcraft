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
		transform.Translate((Vector2)transform.right * moveSpeed * Time.deltaTime);
	}

	protected override void CollideWithEnemy()
	{
		EffectManager.instance.InstantiateBurstEffect(transform.position);
		gameObject.SetActive(false);
	}
	#endregion
}
