using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoyalPunch : Singleton<RoyalPunch>
{
	public event Action<bool> OnGameFinished = null;

    [SerializeField] private EnemyCharacter m_Enemy = null;

	public EnemyCharacter Enemy => m_Enemy;

	private void OnEnable()
	{
		m_Enemy.HealthSystem.OnDeath += OnEnemyDeath;
	}

	private void OnDisable()
	{
		m_Enemy.HealthSystem.OnDeath -= OnEnemyDeath;
	}

	private void OnEnemyDeath(HealthSystem sender)
	{
		OnGameFinished?.Invoke(true);

		FindObjectOfType<InputHandler>().IsInputAllowed = false;
	}
}
