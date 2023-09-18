using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIGold : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI text;
	private int value;
	#endregion

	#region PublicMethod
	public void UpdateGold(int _value)
	{
		if (value == _value)
			return;

		if(value < _value)
		{
			text.DOColor(Color.white, 0.1f).From(Color.green);
			text.transform.DOMoveY(text.transform.position.y, 0.3f).From(text.transform.position.y + 0.05f);
		}
		else
		{
			text.DOColor(Color.white, 0.1f).From(Color.red);
			text.transform.DOMoveY(text.transform.position.y, 0.3f).From(text.transform.position.y - 0.05f);
		}
		value = _value;
		text.text = value.ToString();
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Text").TryGetComponent(out text);
	}
	#endregion
}
