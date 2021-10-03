using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatedElement : MonoBehaviour
{
    [SerializeField] protected bool m_IsActiveState = false;

    public abstract void ChangeState(bool active, bool isImmediately);
}
