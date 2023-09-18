using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIGameEnd : MonoBehaviour
{
	#region PublicVariables
	public static UIGameEnd instance;
	#endregion

	#region PrivateVariables
	private TextMeshProUGUI text;
	private Image image;
	#endregion

	#region PublicMethod
	public void Victory()
	{
		gameObject.SetActive(true);
		image.DOFade(0.8f, 0f);
		text.text = "½Â¸®!";
	}
	public void Defeat()
	{
		gameObject.SetActive(true);
		image.DOFade(0.8f, 0f);
		text.text = "ÆÐ¹è...";
	}
	public void HideAll()
	{
		image.DOFade(0, 0f);
		text.text = "";
		gameObject.SetActive(false);
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		transform.Find("Background").TryGetComponent(out image);
		transform.Find("Text").TryGetComponent(out text);
	}
	private void Start()
	{
		HideAll();
	}
	#endregion
}
