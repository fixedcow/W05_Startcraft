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
	private float textLocalPosY;
	#endregion

	#region PublicMethod
	public void UpdateGold(int _value)
	{
		if (value == _value)
			return;

		if(value < _value)
		{
			text.DOColor(Color.white, 0.3f).From(Color.green);
			text.transform.DOLocalMoveY(textLocalPosY, 0.3f).From(textLocalPosY + 5f);
		}
		else
		{
			text.DOColor(Color.white, 0.3f).From(Color.red);
			text.transform.DOLocalMoveY(textLocalPosY, 0.3f).From(textLocalPosY - 5f);
		}
		value = _value;
		text.text = value.ToString();
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Text").TryGetComponent(out text);
		textLocalPosY = text.transform.localPosition.y;
	}
	#endregion
}
