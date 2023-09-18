using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;

public class AIPathDecider : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Player me;
	private Player other;

	[SerializeField] List<Path> paths = new List<Path>();

	private float timer;
	[SerializeField] private float decisionDelayMin = 1.2f;
	[SerializeField] private float decisionDelayMax = 4.8f;
	[SerializeField] private float lowestMult = 0.8f;
	[SerializeField] private float highestMult = 0.95f;
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
		if (timer > Random.Range(decisionDelayMin, decisionDelayMax))
		{
			timer = 0;
			DecidePath();
		}
	}
	private void DecidePath()
	{
		paths = paths.OrderBy(x => CalculatePathTerritoryCount(x)).ToList();
		float rand = Random.Range(0f, 1f);
		if(rand < lowestMult)
		{
			me.SetPath(paths.First());
		}
		else if(rand < highestMult)
		{
			me.SetPath(paths.Last());
		}
        else
        {
			me.SetPath(paths[1]);
        }
    }
	private int CalculatePathTerritoryCount(Path _path)
	{
		return _path.Tiles.Count(x => x.Owner == me);
	}
	#endregion
}
