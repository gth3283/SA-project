using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTalk : MonoBehaviour
{
    [SerializeField]
    public Talk t;
    private TalkManager m;

    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<TalkManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Z))
        {
            m.ShowTalk(t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
