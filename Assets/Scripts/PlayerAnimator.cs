using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	[SerializeField] private Animator m_Animator = null;

	public void UpdateState(float h, float v)
	{
		m_Animator.SetFloat("Horizontal", h);
		m_Animator.SetFloat("Vertical", v);
	}
}
