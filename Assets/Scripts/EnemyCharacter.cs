using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] private HealthSystem m_HealthSystem = null;

    public HealthSystem HealthSystem => m_HealthSystem;
}
