using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System.Linq;

public class CommandCenter : Unit
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private Path currentPath;
	[SerializeField] private bool isEnemy;
	#endregion

	#region PublicMethod
	[Button]
	public void SpawnUnit()
	{
		Soldier current = SoldierGenerator.instance.InstantiateSoldier(new Vector2(transform.position.x, currentPath.transform.position.y)).GetComponent<Soldier>();
		current.Initialize(owner);
	}
	#endregion

	#region PrivateMethod
	#endregion
}
