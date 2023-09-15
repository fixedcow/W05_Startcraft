using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Sirenix.OdinInspector;

public class Unit : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	private Player Owner;
	private GameObject rend;
	private SpriteRenderer fill;
	private TextMeshPro text;
	[SerializeField] private int Hp;
	#endregion

	#region PublicMethod
	[Button]
	public void Initialize(Player _owner, int _hp)
	{
		Owner = _owner;
		fill.color = Owner.MainColor;
		Hp = _hp;
	}
	#endregion

	#region PrivateMethod
	private void Awake()
	{
		transform.Find("Renderer").TryGetComponent(out rend);
		transform.Find("Text").TryGetComponent(out text);
	}
	private void Update()
	{
		UpdateText();
	}
	private void OnTriggerEnter2D(Collider2D _collision)
	{
		Unit unit;
		if (_collision.TryGetComponent(out unit) == true && unit.Owner != Owner)
		{
			unit.CollideWithEnemy(Hp);
		}
	}

	protected void UpdateText()
	{
		text.transform.localEulerAngles = -transform.eulerAngles;
		text.text = Hp.ToString();
	}
	protected virtual void CollideWithEnemy(int _hp)
	{
		Hp -= _hp;
		if (Hp < 0)
		{
			EffectManager.instance.InstantiateBurstEffect(transform.position);
			Destroy(gameObject);
			return;
		}
		rend.transform.DOShakePosition(0.2f, 0.4f);
	}
	#endregion
}
