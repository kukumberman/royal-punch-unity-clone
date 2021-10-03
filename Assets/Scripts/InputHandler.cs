using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	[SerializeField] private JoystickController m_Joystick = null;
	[SerializeField] private bool m_IsMobileInput = true;

	public bool IsInputAllowed = true;

	public float Horizontal()
	{
		if (!IsInputAllowed) return 0;

		return m_IsMobileInput ? m_Joystick.Horizontal : Input.GetAxis("Horizontal");
	}

	public float Vertical()
	{
		if (!IsInputAllowed) return 0;

		return m_IsMobileInput ? m_Joystick.Vertical : Input.GetAxis("Vertical");
	}
}
