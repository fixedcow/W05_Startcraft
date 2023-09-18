using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private Player me;
	[SerializeField] private Player other;
	private AIPathDecider path;
	private AIReinforceDecider reinforce;
	#endregion

	#region PublicMethod
	public void Initialize()
	{
		path.Initialize(me, other);
		reinforce.Initialize(me, other);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		TryGetComponent(out path);
		TryGetComponent(out reinforce);
	}
	private void Start()
	{
		Initialize();
	}
	#endregion
}
