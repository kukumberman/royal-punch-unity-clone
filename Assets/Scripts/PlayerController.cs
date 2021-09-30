﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 10;
    [SerializeField] private EnemyCharacter m_Enemy = null;

    private Rigidbody m_Rigidbody = null;

    private InputHandler m_Input = null;

    private Vector3 m_InputVector = Vector3.zero;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Input = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        HandleRotation();
    }

	private void FixedUpdate()
	{
        HandlePosition();
    }

	private void HandlePosition()
	{
        m_InputVector.x = m_Input.Horizontal();
        m_InputVector.z = m_Input.Vertical();

        Vector3 dir = transform.TransformDirection(m_InputVector);
        Vector3 translation = dir * m_MoveSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(transform.position + translation);
    }

    private void HandleRotation()
	{
        Vector3 direction = m_Enemy.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
