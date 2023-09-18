using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIProductivity : MonoBehaviour
{
	#region PublicVariables
	public static UIProductivity instance;
	#endregion

	#region PrivateVariables
	private List<UnitProvider> providers;
	private TextMeshProUGUI text;
	#endregion

	#region PublicMethod
	public void SetProviders(List<UnitProvider> _providers)
	{
		providers = _providers;
		UpdateProductivity();
	}
	public void UpdateProductivity()
	{
		int productivity = 0;
		foreach(UnitProvider provider in providers)
		{
			productivity += provider.Productivity;
		}
		text.text = "현재 생산력 : " + ((float)productivity / 10f).ToString() + "/s";
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		transform.Find("text").TryGetComponent(out text);
	}
	#endregion
}
