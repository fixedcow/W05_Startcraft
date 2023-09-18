using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProvider : MonoBehaviour
{
	#region PublicVariables
	[ShowInInspector] public int Level { get { return level; } }
	[ShowInInspector] public int Price { get { return Mathf.RoundToInt(reinforcePriceBase + level * reinforcePriceMult); } }
	[ShowInInspector] public float Duration { get { return Mathf.Round(reinforceDurationBase + level * reinforceDurationMult); } }
	[ShowInInspector] public int Productivity { get { return isReinforcing ? 0 : productivityBase + GetProductivityMult(Level); } }
	#endregion

	#region PrivateVariables
	private Player owner;
	[SerializeField] private UIUnitProvider ui;

	private int level = 1;
	private static int reinforcePriceBase = 10;
	private static float reinforcePriceMult = 40;
	private static float reinforceDurationBase = 2;
	private static float reinforceDurationMult = 3;
	private static int productivityBase = 2;

	private bool isReinforcing = false;
	private float reinforceTimer = 0f;
	#endregion

	#region PublicMethod
	public void SetOwner(Player _owner)
	{
		owner = _owner;
	}
	public void TryReinforce()
	{
        if (owner.RemoveGold(Price))
        {
			isReinforcing = true;
			reinforceTimer = 0f;
			if (ui != null)
			{
				ui.ReinforcingStart();
			}
		}
		else
		{
			if(owner.IsPlayer)
				UIPopupMessage.instance.PrintMessage("골드가 부족합니다!");
		}
	}
	#endregion

	#region PrivateMethod
	private void Update()
	{
		Reinforcement();
	}
	private void Reinforcement()
	{
		if (isReinforcing == false)
			return;

		reinforceTimer += Time.deltaTime;
		if(ui != null)
			ui.UpdateTimer(Duration - reinforceTimer);
		if(reinforceTimer > Duration)
		{
			reinforceTimer = 0f;
			++level;
			isReinforcing = false;
			if (ui != null)
			{
				ui.ReinforcingEnd();
				ui.UpdateInfo(Level, Price, Duration, Productivity, GetProductivityMult(Level - 1));
			}
		}
	}
	private int GetProductivityMult(int _count)
	{
		if(_count == 1 || _count == 0)
		{
			return 1;
		}
		else
		{
			return GetProductivityMult(_count - 1) + GetProductivityMult(_count - 2);
		}
	}
	#endregion
}
