using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedRectTransformPosition : AnimatedElement
{
    [SerializeField] private RectTransform m_RectTransform = null;
    [SerializeField] private InterpolatorVector3 m_PositionInterpolator = null;

    [SerializeField] private Vector3 m_ActivePosition = Vector3.zero;
    [SerializeField] private Vector3 m_InactivePosition = Vector3.zero;

    public override void ChangeState(bool active, bool isImmediately)
    {
        m_IsActiveState = active;

        // todo: figure out how to dynamicly pass prop as arg instead writing same code for different components

        Vector3 startPosition = m_RectTransform.anchoredPosition;
        Vector3 targetPosition = active ? m_ActivePosition : m_InactivePosition;

        if (isImmediately)
        {
            m_RectTransform.anchoredPosition = targetPosition;
        }
        else
        {
            m_PositionInterpolator.Activate(startPosition, targetPosition);
        }
    }

    private void Update()
    {
        if (m_PositionInterpolator.IsActive)
        {
            m_RectTransform.anchoredPosition = m_PositionInterpolator.CurrentValue;
        }
    }

    private void OnValidate()
    {
        if (m_RectTransform == null) return;

        Vector3 pos = m_IsActiveState ? m_ActivePosition : m_InactivePosition;
        m_RectTransform.anchoredPosition = pos;
    }
}
