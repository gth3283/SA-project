using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private FadeManager Fade;
    bool flag;
    void Start()
    {
        Fade = FindObjectOfType<FadeManager>();
        DontDestroyOnLoad(gameObject);
        flag = false;
    }
    IEnumerator FICoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);
        Fade.FadeIn();
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    IEnumerator MainSceneLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main Scene");
    }

    public void titleToMainScene()
    {
        Fade.FadeOut();
        StartCoroutine(MainSceneLoad());
        StartCoroutine(FICoroutine());
    }
}
