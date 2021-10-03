using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedGroup : MonoBehaviour
{
    [SerializeField] private AnimatedElement[] m_Elements = null;

    [Header("Debug")]
    [SerializeField] private bool m_IsActive = false;

    private void OnValidate()
    {
        ChangeStateImmediately(m_IsActive);
    }

    public void ChangeStateImmediately(bool active)
	{
        ChangeState(active, true);
	}

    public void ChangeStateWithTransition(bool active)
    {
        ChangeState(active, false);
    }

    public void ChangeState(bool active, bool isImmediately)
    {
        for (int i = 0; i < m_Elements.Length; i++)
        {
            m_Elements[i].ChangeState(active, isImmediately);
        }
    }
}
