using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	[SerializeField] private JoystickController m_Joystick = null;
	[SerializeField] private bool m_IsMobileInput = true;

	public float Horizontal()
	{
		return m_IsMobileInput ? m_Joystick.Horizontal : Input.GetAxis("Horizontal");
	}

	public float Vertical()
	{
		return m_IsMobileInput ? m_Joystick.Vertical : Input.GetAxis("Vertical");
	}
}
