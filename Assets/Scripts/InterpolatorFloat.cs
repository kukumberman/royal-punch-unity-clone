using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolatorFloat : Interpolator<float>
{
	protected override float Interpolate()
	{
		return Mathf.Lerp(m_StartValue, m_TargetValue, m_SmoothPercentage);
	}
}
