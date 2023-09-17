using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProvider : MonoBehaviour
{
	#region PublicVariables
	public int Level { get { return level; } }
	public int Price { get { return Mathf.RoundToInt(reinforcePriceBase + level * reinforcePriceMult); } }
	public float Duration { get { return Mathf.Round(reinforceDurationBase + level * reinforceDurationMult); } }
	public float Productivity { get { return isReinforcing ? 0 : productivity; } }
	#endregion

	#region PrivateVariables
	private int level = 1;
	[SerializeField] private int reinforcePriceBase;
	[SerializeField] private float reinforcePriceMult;
	[SerializeField] private float reinforceDurationBase;
	[SerializeField] private float reinforceDurationMult;
	private float productivity;

	private bool isReinforcing = false;
	private float reinforceTimer;
	#endregion

	#region PublicMethod
	public void TryReinforce()
	{
		isReinforcing = true;
		reinforceTimer = 0f;
	}
	public void CancelReinforce()
	{
		isReinforcing = false;
	}
	#endregion

	#region PrivateMethod
	private void Update()
	{
		Reinforcement();
	}
	private void Reinforcement()
	{
		reinforceTimer += Time.deltaTime;
		if(reinforceTimer > Duration)
		{
			reinforceTimer = 0f;
			++level;
		}
	}
	#endregion
}
