using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting;

public class Path : MonoBehaviour
{
	#region PublicVariables
	[ShowInInspector] public Vector3[] Points { get; private set; }
	[ShowInInspector] public float Duration
	{
		get
		{
			if (Points != null)
			{
				float result = 0;
				for(int i = 0; i < Points.Length - 1; ++i)
				{
					result += Vector3.Distance(Points[i], Points[i + 1]) * durationPerTile;
				}
				return result;
			}
			else
				return 0;
		}
	}
	[SerializeField] private float durationPerTile = 1;
	#endregion

	#region PrivateVariables

	#endregion

	#region PublicMethod
	#endregion

	#region PrivateMethod
	#endregion
}
