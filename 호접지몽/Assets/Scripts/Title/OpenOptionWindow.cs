using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenOptionWindow : MonoBehaviour
{

    public CanvasGroup a;
    public CanvasGroup b;
    public SpriteRenderer title;
    public SpriteRenderer titleName;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OnOptionButtonClick()
    {
        audioManager.Play("Press");
        a.alpha = 0;
        a.interactable = false;
        b.alpha = 1;
        b.interactable = true;
        title.color = new Color(30 / 255f, 30 / 255f, 30 / 255f);
        titleName.color = new Color(30 / 255f, 30 / 255f, 30 / 255f);
    }
}
