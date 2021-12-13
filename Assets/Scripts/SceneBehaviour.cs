using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (Core.Instance)
            return;

        Core core = new GameObject("Core").AddComponent<Core>();

        core.Init();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }
}
