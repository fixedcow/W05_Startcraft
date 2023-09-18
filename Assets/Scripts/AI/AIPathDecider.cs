using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIPathDecider : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Player me;
	private Player other;

	[SerializeField] List<Path> paths = new List<Path>();

	private float timer;
	[SerializeField] private float decisionDelay = 2f;
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
		if(timer > decisionDelay )
		{
			timer = 0;
			DecidePath();
		}
	}
	private void DecidePath()
	{
		paths.OrderBy(x => CalculatePathTerritoryCount(x.Tiles.ToList()));
		float rand = Random.Range(0, 1);
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
	private int CalculatePathTerritoryCount(List<GridTile> _path)
	{
		return _path.Where(x => x.Owner == me).Count();
	}
	#endregion
}
