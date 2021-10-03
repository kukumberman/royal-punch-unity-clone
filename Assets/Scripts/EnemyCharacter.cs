using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    [SerializeField] private HealthSystem m_HealthSystem = null;

    public HealthSystem HealthSystem => m_HealthSystem;

	private void OnEnable()
	{
		HealthSystem.OnDeath += OnDeath;
	}

	private void OnDisable()
	{
		HealthSystem.OnDeath -= OnDeath;
	}

	private void OnDeath(HealthSystem _)
	{
		DisableMesh();
	}

	private void DisableMesh()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}

	[ContextMenu("Remove Ragdoll")]
    private void RemoveRagdoll()
	{
        var parent = transform.GetChild(0);
        var rbs = parent.GetComponentsInChildren<Rigidbody>();
        var colliders = parent.GetComponentsInChildren<Collider>();
        var joints = parent.GetComponentsInChildren<CharacterJoint>();

        Remove(joints);
        Remove(rbs);
        Remove(colliders);

        void Remove(Component[] arr)
		{
            foreach(Component entry in arr)
			{
                DestroyImmediate(entry);
			}
		}
	}
}
