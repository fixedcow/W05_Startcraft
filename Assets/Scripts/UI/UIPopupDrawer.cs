using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIPopupDrawer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private UIPopup popup;
	#endregion

	#region PublicMethod
	public void OnPointerEnter(PointerEventData eventData)
	{
		popup.Show();
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		popup.Hide();
	}
	#endregion

	#region PrivateMethod
	#endregion
}
