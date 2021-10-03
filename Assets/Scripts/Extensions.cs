using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Extensions
{
    public static void InvokeAfterDelay(this MonoBehaviour mono, Action action, float delay)
    {
        mono.StartCoroutine(InvokeAfterDelayRoutine(action, delay));
    }

    private static IEnumerator InvokeAfterDelayRoutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);

        action();
    }
}
