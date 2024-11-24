using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 로딩을 위한 네임스페이스
using System.Collections;  // IEnumerator를 사용하기 위한 네임스페이스 추가

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName;
    private FadeManager Fade;

    // Start is called before the first frame update
    void Awake()
    {
        Fade = FindObjectOfType<FadeManager>();
        Fade.FadeIn(0.001f);
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(FadeCoroutine()); 
        }
    }

    
    IEnumerator FadeCoroutine()
    {
        Debug.Log("씬 이동.");
        Fade.FadeOut(); 
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(targetSceneName);  

        yield return new WaitForSeconds(1f);  

        Fade.FadeIn(0.001f);  
    }
}
