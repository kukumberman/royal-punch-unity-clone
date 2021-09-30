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

	public event Action<OnHealthChangedEventArgs> OnHealthChanged = null;

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
		m_CurrentAmount = Mathf.Max(0, m_CurrentAmount - amount);

		ForceEvent();
	}
}
