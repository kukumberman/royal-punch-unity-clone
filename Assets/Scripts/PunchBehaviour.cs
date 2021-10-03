using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBehaviour : MonoBehaviour
{
    [SerializeField] private float m_MaxRayDistance = 1;
    [SerializeField] private int m_DamageAmount = 10;

    [SerializeField] private PlayerAnimator m_Animator = null;

    private bool m_IsNearEnemy = false;
    private HealthSystem m_EnemyHealth = null;

    private void Update()
    {
        HandlePunch();
    }

    private void HandlePunch()
	{
        Ray ray = new Ray(transform.position + Vector3.up, transform.forward);

        m_IsNearEnemy = Physics.Raycast(ray, out var hit, m_MaxRayDistance);

        if (m_IsNearEnemy)
		{
            if (hit.transform.TryGetComponent<HealthSystem>(out var hs))
			{
                m_EnemyHealth = hs;
			}
		}

        m_Animator.NearEnemy(m_IsNearEnemy);

        if (m_IsNearEnemy)
		{
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
		else
		{
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * m_MaxRayDistance, Color.red);
		}
	}

    private void DoPunch()
	{
        if (m_IsNearEnemy)
		{
            m_EnemyHealth.TakeDamage(m_DamageAmount);
		}
	}
}
