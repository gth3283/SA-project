using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class SceneChange : MonoBehaviour
{
    private FadeManager Fade;
    public GameObject Loading;
    public Text LoadingText;
    private Color color;

    public static SceneChange Instance
    {
        get { return instance; }
    }
    private static SceneChange instance;

    void Start()
    {
        instance = this;
        Fade = FindObjectOfType<FadeManager>();
    }
    public void ChangeScene(string sceneName) //씬 전환
    {
        StartCoroutine(FICoroutine());
        StartCoroutine(LoadScene(sceneName)); //로딩 시작
    }

    IEnumerator FICoroutine()
    {
        color = Fade.black.color;
        while (color.a < 1f)
        {
            color.a += 0.002f;
            Fade.black.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(0.6f);
        Loading.SetActive(true); //로딩창 활성화

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName); //비동기 씬 로딩 시작
        async.allowSceneActivation = false;

        float past_time = 0; //경과 시간
        float percentage = 0; //로딩 퍼센트

        while (!(async.isDone)) //씬이 로딩중이라면 반복
        {
            yield return null;
            past_time += Time.deltaTime;
            if(percentage >= 90) {
                percentage = Mathf.Lerp(percentage, 100, past_time);
                if(percentage == 100)
                    async.allowSceneActivation = true; //다음 씬 표시
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if(percentage >= 90)
                    past_time = 0;
            }
            LoadingText.text = percentage.ToString("0") + "%"; //퍼센트 표기
        }
        Loading.SetActive(false); //로딩창 끄기
        color = Fade.black.color;
        color.a = 0f;
        Fade.black.color = color;
        Fade.FadeIn();
    }

}
