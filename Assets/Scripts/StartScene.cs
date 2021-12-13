using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : SceneBehaviour
{
    [SerializeField] private string _loadSceneName;
    [SerializeField] private LoadController _loadController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _loadController.LoadScene(_loadSceneName);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
