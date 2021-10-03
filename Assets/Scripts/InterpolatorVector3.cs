using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolatorVector3 : Interpolator<Vector3>
{
	protected override Vector3 Interpolate()
	{
		return Vector3.Lerp(m_StartValue, m_TargetValue, m_SmoothPercentage);
	}
}
