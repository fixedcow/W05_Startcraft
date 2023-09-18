using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPopupMessage : MonoBehaviour
{
	#region PublicVariables
	public static UIPopupMessage instance;
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI text;
	#endregion

	#region PublicMethod
	public void SetActive()
	{
		gameObject.SetActive(true);
	}
	public void SetDeactive()
	{
		gameObject.SetActive(false);
	}
	public void PrintMessage(string _str)
	{
		SetDeactive();
		text.text = _str;
		SetActive();
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
			instance = this;
		transform.Find("Text").TryGetComponent(out text);
		SetDeactive();
	}
	#endregion
}
