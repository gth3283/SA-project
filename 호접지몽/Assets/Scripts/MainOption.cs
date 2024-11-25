using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOption : MonoBehaviour
{
    public CanvasGroup c;
    private AudioManager audioManager;
    public MovingObject player;
    private bool open;
    private MainOption instance = null;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        open = true;
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O)&&open)
        {
            audioManager.Play("Press");
            c.alpha = 1;
            c.interactable = true;
            open = false;
            player.StopMove();
        }
        else if(Input.GetKeyUp(KeyCode.O) && !open)
        {
            audioManager.Play("Press");
            c.alpha = 0;
            c.interactable = false;
            open = true;
            player.CanMove();
        }
    }
}
