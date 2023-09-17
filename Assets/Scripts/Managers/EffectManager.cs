using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectManager : MonoBehaviour
{
	#region PublicVariables
	public static EffectManager instance;
	#endregion

	#region PrivateVariables
	[SerializeField] private GameObject burstEffectPrefab;
	private List<GameObject> burstEffects = new List<GameObject>();
	[SerializeField] private GameObject selectedPathAnimation;
	#endregion

	#region PublicMethod
	public void InstantiateBurstEffect(Vector2 _position)
	{
		GameObject current = GetNewBurstEffect();
		current.transform.position = _position;
	}
	public void HighlightSelectedPath(Vector2 _position)
	{
		selectedPathAnimation.transform.position = _position;
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
	}
	private GameObject GetNewBurstEffect()
	{
		GameObject current = null;
		for(int i = 0; i < burstEffects.Count; ++i)
		{
			if (burstEffects[i].activeSelf == false)
			{
				current = burstEffects[i];
				break;
			}
		}
		if(current == null)
		{
			current = Instantiate(burstEffectPrefab, transform) as GameObject;
			burstEffects.Add(current);
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
