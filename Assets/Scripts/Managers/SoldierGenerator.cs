using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierGenerator : MonoBehaviour
{
	#region PublicVariables
	public static SoldierGenerator instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject soldierPrefab;
	private List<GameObject> soldiers = new List<GameObject>();
	#endregion

	#region PublicMethod
	public GameObject InstantiateSoldier(Vector2 _position)
	{
		GameObject current = GetNewSoldier();
		current.transform.position = _position;
		return current;
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}
	private GameObject GetNewSoldier()
	{
		GameObject current = null;
		for (int i = 0; i < soldiers.Count; ++i)
		{
			if (soldiers[i].activeSelf == false)
			{
				current = soldiers[i];
				break;
			}
		}
		if (current == null)
		{
			current = Instantiate(soldierPrefab, transform) as GameObject;
			soldiers.Add(current);
			return current;
		}
		else
		{
			current.SetActive(true);
			return current;
		}
	}
	#endregion
}
