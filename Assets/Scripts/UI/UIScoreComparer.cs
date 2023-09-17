using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScoreComparer : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] UIScore playerScore;
	[SerializeField] UIScore enemyScore;
	#endregion

	#region PublicMethod
	public void Compare()
	{
		if(playerScore.Score > enemyScore.Score)
		{
			playerScore.transform.DOKill();
			enemyScore.transform.DOKill();
			playerScore.transform.DOScale(1.2f, 0.4f).SetEase(Ease.OutBack);
			enemyScore.transform.DOScale(0.9f, 0.4f).SetEase(Ease.OutBack);
		}
		else if(playerScore.Score < enemyScore.Score)
		{
			playerScore.transform.DOKill();
			enemyScore.transform.DOKill();
			playerScore.transform.DOScale(0.9f, 0.4f).SetEase(Ease.OutBack);
			enemyScore.transform.DOScale(1.2f, 0.4f).SetEase(Ease.OutBack);
		}
		else
		{
			playerScore.transform.DOKill();
			enemyScore.transform.DOKill();
			playerScore.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);
			enemyScore.transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
