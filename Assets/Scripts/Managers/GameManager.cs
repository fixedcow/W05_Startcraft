using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;

	public Player Player { get { return player; } }
	public Player Enemy { get { return enemy; } }
	#endregion

	#region PrivateVariables
	[SerializeField] Player player;
	[SerializeField] Player enemy;

	[SerializeField] private float goldProvidingTime = 1f;
	private float goldProvidingTimer;
	#endregion

	#region PublicMethod
	[Button]
	public void Victory()
	{
		UIGameEnd.instance.Victory();
		Time.timeScale = 0.001f;
	}
	[Button]
	public void Defeat()
	{
		UIGameEnd.instance.Defeat();
		Time.timeScale = 0.001f;
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	private void Update()
	{
		ProvideGold();
	}
	private void ProvideGold()
	{
		goldProvidingTimer += Time.deltaTime;
		if(goldProvidingTimer > goldProvidingTime )
		{
			goldProvidingTimer = 0f;
			player.ProvideGold();
			enemy.ProvideGold();
		}
	}
	#endregion
}
