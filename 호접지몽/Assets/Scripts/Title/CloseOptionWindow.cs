using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptionWindow : MonoBehaviour
{
    public CanvasGroup a;
    public CanvasGroup b;
    public SpriteRenderer title;
    public SpriteRenderer titleName;

    public void OnCloseButtonClick()
    {
        a.alpha = 1;
        a.interactable = true;
        b.alpha = 0;
        b.interactable = false;
        title.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        titleName.color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    }
}
