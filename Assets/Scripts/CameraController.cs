using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Pivot = null;
    [SerializeField] private InterpolatorVector3 m_RotationInterpoltor = null;
	[SerializeField] private Vector3 m_TargetRotation = Vector3.zero;

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
		this.InvokeAfterDelay(() =>
		{
			m_RotationInterpoltor.Activate(m_Pivot.localEulerAngles, m_TargetRotation);
		}, 1);
	}

	private void Update()
    {
        if (m_RotationInterpoltor.IsActive)
		{
            m_Pivot.localEulerAngles = m_RotationInterpoltor.CurrentValue;
		}
    }
}
