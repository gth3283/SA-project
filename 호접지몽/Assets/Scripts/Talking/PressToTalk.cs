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

    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<TalkManager>();
        p = FindObjectOfType<MovingObject>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z)) { 
            m.ShowTalk(t);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
