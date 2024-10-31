using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startpoint;
    private MovingObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovingObject>();
        if (startpoint == player.MapName)
        {
            player.transform.position=transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
