using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnitProvider : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private GameObject unitProviderButton;
	private GameObject reinforcingSprite;
	private UIUnitProviderInfo unitProviderInfo;
	private UIReinforcingInfo reinforcingInfo;
	#endregion

	#region PublicMethod
	public void UpdateInfo(int _level, int _price, float _duration, int _productivity, int _productivityAdditive)
	{
		unitProviderInfo.UpdateInfo(_level, _price, _duration, _productivity, _productivityAdditive);
	}
	public void UpdateTimer(float  _timer)
	{
		reinforcingInfo.UpdateInfo(_timer);
	}
	public void ReinforcingStart()
	{
		unitProviderButton.SetActive(false);
		reinforcingSprite.SetActive(true);
	}
	public void ReinforcingEnd()
	{
		reinforcingSprite.SetActive(false);
		unitProviderButton.SetActive(true);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		unitProviderButton = transform.Find("Unit Provider Button").gameObject;
		reinforcingSprite = transform.Find("Reinforcing").gameObject;
		transform.Find("Unit Provider Button/Info").TryGetComponent(out unitProviderInfo);
		transform.Find("Reinforcing/Info").TryGetComponent(out reinforcingInfo);
	}
	#endregion
}
