using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : SingletonBehaviour<Core>
{
    [SerializeField] private float _fixedDeltaTime = 0.002f;

    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = _fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Init()
    {
        List<SingletonBehaviour> list = new List<SingletonBehaviour>();

        list.Add(AddComponent<RankingManager>());

        foreach (var b in list)
            b.Init();
    }

    protected override void AwakeChild()
    {
        DontDestroyOnLoad(gameObject);
    }

    T AddComponent<T>() where T : SingletonBehaviour
    {
        return gameObject.AddComponent<T>();
    }
}
