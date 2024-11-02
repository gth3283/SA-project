using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private FadeManager Fade;
    void Start()
    {
        Fade = FindObjectOfType<FadeManager>();
    }

    IEnumerator FadeCoroutine()
    {
        yield return new WaitForSeconds(2f);
        Fade.FadeIn(0.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FadeCoroutine());
    }
}
