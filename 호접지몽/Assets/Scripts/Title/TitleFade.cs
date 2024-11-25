using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build;
using UnityEngine;

public class Title : MonoBehaviour
{
    private FadeManager Fade;
    public CanvasGroup c;
    private bool a = true;
    void Start()
    {
        Fade = FindObjectOfType<FadeManager>();
    }

    IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Fade.FadeIn(0.0001f);
    }

    IEnumerator CanvasCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        if (a)
        {
            while (c.alpha < 1f)
            {
                c.alpha += 0.01f;
                yield return new WaitForSeconds(0.1f);
            }
            a = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FadeCoroutine());
        StartCoroutine(CanvasCoroutine());
    }
}
