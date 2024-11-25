using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InGameStart : MonoBehaviour
{
    [SerializeField]
    public Talk t;
    private TalkManager m;
    private FadeManager fadeManager;
    bool one = true;
    public CanvasGroup g;

    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<TalkManager>();
        fadeManager = FindObjectOfType<FadeManager>();

        fadeManager.FadeOut(1);
        m.ShowTalk(t);
    }
     private void Update()
    {
        if (one)
        {
            if (!m.talking)
            {
                //coroutine > chapter 1;
                g.alpha = 0;
                fadeManager.FadeIn();
                one = false;
            }
        }
    }
}
