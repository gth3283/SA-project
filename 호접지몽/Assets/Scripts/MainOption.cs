using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOption : MonoBehaviour
{
    public CanvasGroup c;
    public CanvasGroup c2;
    private AudioManager audioManager;
    public MovingObject player;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O)&&open)
        {
            audioManager.Play("Press");
            c.alpha = 1;
            c2.alpha = 1;
            c.interactable = true;
            open = false;
            player.StopMove();
        }
        else if(Input.GetKeyUp(KeyCode.O) && !open)
        {
            audioManager.Play("Press");
            c.alpha = 0;
            c2.alpha = 0;
            c.interactable = false;
            open = true;
            player.CanMove();
        }
    }
}
