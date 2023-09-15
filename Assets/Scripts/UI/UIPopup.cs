using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIPopup : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI textLevel;
	private TextMeshProUGUI textReinforceDuration;
	private TextMeshProUGUI textReinforcePrice;
	private TextMeshProUGUI textCombatPower;
	private TextMeshProUGUI textProduceDelay;
	#endregion

	#region PublicMethod
	public void Show()
	{
		UpdateInfo();
		transform.DOScale(1, 0.1f);
	}
	public void Hide()
	{
		transform.DOScale(0, 0.1f);
	}
	public void UpdateInfo()
	{

	}
	#endregion

	#region PrivateMethod
	private void Start()
	{
		Hide();
	}
	#endregion
}
