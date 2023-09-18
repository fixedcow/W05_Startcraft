using JetBrains.Annotations;
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
	[SerializeField] private float decisionDelay = 0.2f;
	[SerializeField] private float highestReinforceMult = 1.2f;
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
		List<UnitProvider> list = me.Providers.OrderBy(x => x.Level).Where(x => x.IsReinforcing == false).ToList();
		UnitProvider high = list.Last();
		UnitProvider low = list.First();
		if (me.TerritoryCount > highestReinforceMult * other.TerritoryCount && me.Gold >= high.Price)
		{
			high.TryReinforce();
		}
		else if(me.TerritoryCount > lowestReinforceMult * other.TerritoryCount && me.Gold >= low.Price)
		{
			low.TryReinforce();
		}
		// else invade.
	}
	#endregion
}
