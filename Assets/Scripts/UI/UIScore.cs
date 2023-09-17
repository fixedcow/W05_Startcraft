using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIScore : MonoBehaviour
{
	#region PublicVariables
	public int Score { get { return score; } }
	#endregion

	#region PrivateVariables
	private UIScoreComparer comparer;
	private TextMeshProUGUI text;

	private int score;
	#endregion

	#region PublicMethod
	public void UpdateScore(int _score)
	{
		if(score != _score)
		{
			transform.DOScale(transform.localScale.x, 0.4f).From(transform.localScale.x * 1.1f);
			score = _score;
			text.text = score.ToString();
			comparer.Compare();
		}
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.parent.TryGetComponent(out comparer);
		TryGetComponent(out text);
	}
	#endregion
}
