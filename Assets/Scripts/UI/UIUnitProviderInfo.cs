using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUnitProviderInfo : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI levelText;
	private TextMeshProUGUI priceText;
	private TextMeshProUGUI durationText;
	private TextMeshProUGUI productivityText;
	#endregion

	#region PublicMethod
	public void UpdateInfo(int _level, int _price, float _duration, int _productivity, int _productivityAdditive)
	{
		levelText.text = "Lv" + _level.ToString();
		priceText.text = _price.ToString() + "G";
		durationText.text = _duration.ToString() + "√ ";
		productivityText.text = ((float)_productivity / 10f).ToString() + "(+" + ((float)_productivityAdditive / 10f).ToString() + ")";
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Level Text").TryGetComponent(out levelText);
		transform.Find("Price Text").TryGetComponent(out priceText);
		transform.Find("Duration Text").TryGetComponent(out durationText);
		transform.Find("Productivity Text").TryGetComponent(out productivityText);
	}
	#endregion
}
