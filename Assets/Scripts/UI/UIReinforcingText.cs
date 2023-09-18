using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIReinforcingText : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI text;
	private float timer = 0f;
	[SerializeField] private float interval = 0.3f;
	#endregion

	#region PublicMethod
	public void SetText(string _str)
	{
		text.text = _str;
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		TryGetComponent(out text);
	}
	private void Update()
	{
		timer += Time.deltaTime;
		if(timer < interval)
		{
			SetText("��ȭ ��");
		}
		else if (timer < 2 * interval)
		{
			SetText("��ȭ ��.");
		}
		else if (timer < 3 * interval)
		{
			SetText("��ȭ ��..");
		}
		else if(timer < 4 * interval)
		{
			SetText("��ȭ ��...");
		}
		else
		{
			timer = 0;
		}
	}
	#endregion
}
