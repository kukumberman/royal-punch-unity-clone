using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

#pragma warning disable CS0414

public abstract class Interpolator<T> : MonoBehaviour where T : struct
{
    [SerializeField] private float m_Duration = 1;
    [SerializeField] private AnimationCurve m_SmoothCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField, TextArea] private string m_Description = "Base Interpolator";
    [Space]
    [SerializeField] protected T m_StartValue = default;
    [SerializeField] protected T m_TargetValue = default;

    private bool m_IsActive = false;
    protected T m_CurrentValue = default;
    protected float m_Percentage01 = 0;
    protected float m_SmoothPercentage = 0;

    private Action m_OnComplete = null;

    public bool IsActive => m_IsActive;
    public T CurrentValue => m_CurrentValue;

    private void Update()
    {
        if (m_IsActive)
        {
            m_Percentage01 += 1f / m_Duration * Time.deltaTime;
            m_SmoothPercentage = m_SmoothCurve.Evaluate(m_Percentage01);
            m_CurrentValue = Interpolate();

            if (m_Percentage01 >= 1)
            {
                m_IsActive = false;
                m_OnComplete?.Invoke();
            }
        }
    }

    protected abstract T Interpolate();

    public void SetCompleteAction(Action onComplete)
    {
        m_OnComplete = onComplete;
    }

    public void Activate(Action onComplete = null)
    {
        m_Percentage01 = 0;
        m_IsActive = true;

        m_OnComplete = onComplete;
    }

    public void Activate(T startValue, T targetValue, Action onComplete = null)
    {
        m_StartValue = m_CurrentValue = startValue;
        m_TargetValue = targetValue;

        Activate(onComplete);
    }
}