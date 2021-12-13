using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadController : MonoBehaviour
{
    private AsyncOperation _load;
    [SerializeField] private UnityEngine.UI.Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadScene(string sceneName)
    {
        if (_load != null)
            return;

        _load = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        if (_load == null)
            return;

        _load.allowSceneActivation = false;

        gameObject.SetActive(true);

        AudioSource soundScorce = Camera.main.GetComponent<AudioSource>();

        if (soundScorce)
            soundScorce.Stop();

        StartCoroutine(ProgressState());
    }

    void AnimationEnd()
    {
        if (_load != null)
            _load.allowSceneActivation = true;
    }

    IEnumerator ProgressState()
    {
        while (true)
        {
            _slider.value = _load.progress;

            yield return null;
        }
    }
}
