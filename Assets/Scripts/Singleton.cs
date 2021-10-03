using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T m_Instance = null;

    public static T Instance
	{
		get
		{
			if (m_Instance == null)
			{
				m_Instance = FindObjectOfType<T>();
			}

			return m_Instance;
		}
	}

	protected virtual void Awake()
	{
		if (m_Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			m_Instance = this as T;
			DontDestroyOnLoad(gameObject);
		}
	}
}
