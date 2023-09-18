using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;

public class CommandCenter : Camp
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private Path currentPath;
	#endregion

	#region PublicMethod
	public void SetPath(Path _path)
	{
		currentPath = _path;
	}
	public void SpawnUnit()
	{
		if (gameObject.activeSelf == false)
			return;
		Soldier current = SoldierGenerator.instance.InstantiateSoldier(new Vector2(transform.position.x, currentPath.transform.position.y)).GetComponent<Soldier>();
		current.Initialize(owner);
	}
	#endregion

	#region PrivateMethod
	protected override void CollideWithEnemy()
	{
		--hp;
		UpdateHp();
		if (hp <= 0)
		{
			EffectManager.instance.InstantiateDestroyedEffect(transform.position);
			if(owner.IsPlayer == true)
			{
				GameManager.instance.Defeat();
			}
			else
			{
				GameManager.instance.Victory();
			}
		}
	}
	#endregion
}
