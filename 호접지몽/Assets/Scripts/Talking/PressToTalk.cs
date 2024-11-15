using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class TestTalk : MonoBehaviour
{
    [SerializeField]
    public Talk t;
    private TalkManager m;
    private MovingObject p;
    private AudioManager a;
   // private bool talking;

    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<TalkManager>();
        a = FindObjectOfType<AudioManager>();
        p = FindObjectOfType<MovingObject>();
        //talking = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!m.a)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                a.Play("Press");
              // talking = true;
                m.ShowTalk(t);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       // if (!m.a)
       // {
           // talking = false;
       // }
    }
}
