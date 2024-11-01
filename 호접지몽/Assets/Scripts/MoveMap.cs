using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    public GameObject movemap;
    private CameraManager Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Cam.target = movemap;
        }
    }
}
