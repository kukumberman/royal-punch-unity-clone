using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
	[SerializeField] private AnimatedGroup m_AnimatedGroup = null;

	private void Start()
	{
		m_AnimatedGroup.ChangeStateImmediately(true);
	}

	private void OnEnable()
	{
		RoyalPunch.Instance.OnGameFinished += OnGameFinished;
	}

	private void OnDisable()
	{
		RoyalPunch.Instance.OnGameFinished -= OnGameFinished;
	}

	private void OnGameFinished(bool success)
	{
		m_AnimatedGroup.ChangeStateWithTransition(false);
	}
}
