using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
	[SerializeField] private AnimatedGroup m_AnimatedGroup = null;

	private void Start()
	{
		m_AnimatedGroup.ChangeStateImmediately(false);
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
		FindObjectOfType<JoystickController>()?.gameObject.SetActive(false);

		this.InvokeAfterDelay(() =>
		{
			m_AnimatedGroup.ChangeStateWithTransition(true);
		}, 1);
	}
}
