using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	#region PublicVariables
	public UnityEvent onButtonClicked;
	#endregion

	#region PrivateVariables
	private bool isEnter = false;
	private bool isDown = false;
	#endregion

	#region PublicMethod
	public void OnPointerEnter(PointerEventData eventData)
	{
		isEnter = true;
		transform.DOScale(1.05f, 0.1f);
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		isEnter = false;
		transform.DOScale(1f, 0.1f);
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		isDown = true;
		transform.DOScale(0.95f, 0.1f);
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		if(isDown == true && isEnter == true)
		{
			transform.DOScale(1.05f, 0.1f).From(1.2f);
			onButtonClicked.Invoke();
		}
		isDown = false;
	}
	#endregion

	#region PrivateMethod
	#endregion
}
