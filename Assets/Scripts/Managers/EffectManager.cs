using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
	#region PublicVariables
	public static EffectManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject burstEffectPrefab;
	#endregion

	#region PublicMethod
	public void InstantiateBurstEffect(Vector2 _position)
	{
		Instantiate(burstEffectPrefab, _position, Quaternion.identity);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}
	#endregion
}
