using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
	public class OnHealthChangedEventArgs
	{
		public HealthSystem Sender { get; }

		public OnHealthChangedEventArgs(HealthSystem sender)
		{
			Sender = sender;
		}
	}

	public class OnDamageTakenEventArgs
	{
		public HealthSystem Sender { get; }
		public int DamageAmount { get; }
		public OnDamageTakenEventArgs(HealthSystem sender, int damageAmount)
		{
			Sender = sender;
			DamageAmount = damageAmount;
		}
	}

	public event Action<OnDamageTakenEventArgs> OnDamageTaken = null;

	public event Action<OnHealthChangedEventArgs> OnHealthChanged = null;

	public event Action<HealthSystem> OnDeath = null;

	[SerializeField] private int m_StartAmount = 50;
	[SerializeField] private int m_MaxAmount = 100;

	private int m_CurrentAmount = 0;

	public int CurrentAmount => m_CurrentAmount;
	public int MaxAmount => m_MaxAmount;

	private void Awake()
	{
		m_CurrentAmount = m_StartAmount;
	}

	private void Start()
	{
		ForceEvent();
	}

	private void ForceEvent()
	{
		OnHealthChanged?.Invoke(new OnHealthChangedEventArgs(this));
	}

    public void TakeDamage(int amount)
	{
		if (m_CurrentAmount == 0) return;

		m_CurrentAmount = Mathf.Max(0, m_CurrentAmount - amount);

		OnDamageTaken?.Invoke(new OnDamageTakenEventArgs(this, amount));

		if (m_CurrentAmount == 0)
		{
			OnDeath?.Invoke(this);
		}

		ForceEvent();
	}
}
