using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitgame : MonoBehaviour
{
    private AudioManager a;

    private void Start()
    {
        a = FindObjectOfType<AudioManager>();
    }
    public void OnQuitButtonClick()
    {
        a.Play("Press");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
