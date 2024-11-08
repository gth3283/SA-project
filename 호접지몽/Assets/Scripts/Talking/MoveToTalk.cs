using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTalk : MonoBehaviour
{
    [SerializeField]
    public Talk t;
    private TalkManager m;
    private MovingObject p;
    private bool onlyOne = true;

    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<TalkManager>();
        p = FindObjectOfType<MovingObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onlyOne)
        {
            m.ShowTalk(t);
            onlyOne = false;
        }
    }
}
