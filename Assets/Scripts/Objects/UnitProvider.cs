using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProvider : MonoBehaviour
{
	#region PublicVariables
	private float Productivity { get { return productivity; } }
	#endregion

	#region PrivateVariables
	private int level = 1;
	private int reinforcePrice;
	private int reinforceDuration;
	private float productivity;
	#endregion

	#region PublicMethod
	public void TryReinforce()
	{

	}
	public void CancelReinforce()
	{

	}
	#endregion

	#region PrivateMethod
	#endregion
}
