using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class CameraManager : MonoBehaviour
{
	#region PublicVariables
	public static CameraManager instance;
	#endregion

	#region PrivateVariables
	private Vector3 originPosition = new Vector3(0, 0.5f, -10f);
	#endregion

	#region PublicMethod
	[Button]
	public void Shake()
	{
		transform.DOShakePosition(0.6f, 0.4f).OnComplete(() => transform.position = originPosition);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}
	#endregion
}
