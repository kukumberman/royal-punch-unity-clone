using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = UnityEngine.UI.Text;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthSystem m_Owner = null;
	[SerializeField] private Vector3 m_Offset = Vector3.zero;

    [SerializeField] private Image m_ProgressImage = null;
    [SerializeField] private Text m_Label = null;

	private void OnEnable()
	{
		m_Owner.OnHealthChanged += OnHealthChanged;
		RoyalPunch.Instance.OnGameFinished += OnGameFinished;
	}

	private void OnDisable()
	{
		m_Owner.OnHealthChanged -= OnHealthChanged;
		RoyalPunch.Instance.OnGameFinished -= OnGameFinished;
	}

	private void LateUpdate()
	{
		transform.position = Camera.main.WorldToScreenPoint(m_Owner.transform.position + m_Offset);
	}

	private void OnHealthChanged(HealthSystem.OnHealthChangedEventArgs args)
	{
		m_Label.text = $"{m_Owner.CurrentAmount}";

		m_ProgressImage.fillAmount = (float)m_Owner.CurrentAmount / m_Owner.MaxAmount;
	}

	private void OnGameFinished(bool success)
	{
		gameObject.SetActive(false);
	}
}
