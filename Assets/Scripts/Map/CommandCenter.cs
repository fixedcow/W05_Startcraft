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
	[SerializeField] private bool isEnemy;
	#endregion

	#region PublicMethod
	public void SetPath(Path _path)
	{
		currentPath = _path;
	}
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
