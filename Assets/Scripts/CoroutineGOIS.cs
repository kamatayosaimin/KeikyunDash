using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutineGOIS
{

    public static IEnumerator State(System.Action<float> arg, float span)
    {
        for (float t = 0f; t < span; t += Time.deltaTime)
        {
            arg(t / span);

            yield return null;
        }

        arg(1f);
    }
}
