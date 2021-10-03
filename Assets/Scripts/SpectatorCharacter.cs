using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorCharacter : MonoBehaviour
{
    [SerializeField] private Animator m_Animator = null;

    private void Start()
    {
		float percentage01 = Random.Range(0, 1f);
        m_Animator.SetFloat("RandomIndex", percentage01);
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
		m_Animator.SetTrigger("Finish");
	}
}
