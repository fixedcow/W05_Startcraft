using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIReinforcingInfo : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI timerText;
	#endregion

	#region PublicMethod
	public void UpdateInfo(float _timer)
	{
		timerText.text = string.Format("{0:N1}", _timer) + "√ ";
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Timer Text").TryGetComponent(out timerText);
	}
	#endregion
}
