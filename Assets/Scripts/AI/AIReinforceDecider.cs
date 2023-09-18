using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIReinforceDecider : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Player me;
	private Player other;

	private float timer;
	[SerializeField] private float decisionDelay = 3f;
	[SerializeField] private float highestReinforceMult = 1.3f;
	[SerializeField] private float lowestReinforceMult = 0.8f;
	#endregion

	#region PublicMethod
	public void Initialize(Player _me, Player _other)
	{
		me = _me;
		other = _other;
	}
	#endregion

	#region PrivateMethod
	private void Update()
	{
		timer += Time.deltaTime;
		if (timer > decisionDelay)
		{
			timer = 0;
			DecideReinforcement();
		}
	}
	private void DecideReinforcement()
	{
		List<UnitProvider> list = me.Providers.OrderBy(x => x.Level).ToList();
		UnitProvider high = list.Last();
		UnitProvider low = list.First();
		if (me.TerritoryCount > highestReinforceMult * other.TerritoryCount && me.Gold >= high.Price)
		{
			Debug.Log("high : " + me.TerritoryCount + " > " + other.TerritoryCount + " * " + highestReinforceMult);
			high.TryReinforce();
		}
		else if(me.TerritoryCount > lowestReinforceMult * other.TerritoryCount && me.Gold >= low.Price)
		{
			Debug.Log("low : " + me.TerritoryCount + " > " + other.TerritoryCount + " * " + lowestReinforceMult);
			low.TryReinforce();
		}
		// else invade.
	}
	#endregion
}
