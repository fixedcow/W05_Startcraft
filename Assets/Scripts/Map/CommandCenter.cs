using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CommandCenter : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject unitPrefab;
	private Vector3[] points;
	#endregion

	#region PublicMethod
	public void SetPoints(Vector3[] _points)
	{
		points = _points;
	}
	public void SpawnUnit()
	{
		GameObject current = Instantiate(unitPrefab, transform.position, Quaternion.identity, transform) as GameObject;
	}
	#endregion

	#region PrivateMethod
	#endregion
}
