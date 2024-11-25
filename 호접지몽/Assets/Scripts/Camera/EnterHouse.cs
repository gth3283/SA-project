using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    public GameObject CamMove;
    public Transform target;
    private CameraManager Cam;
    private FadeManager Fade;
    private MovingObject player;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        Fade = FindObjectOfType<FadeManager>();
        Fade.FadeIn(0.001f);
        Cam = FindObjectOfType<CameraManager>();
        player = FindObjectOfType<MovingObject>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player"&&Input.GetKey(KeyCode.Z))
        {
            audioManager.Play("Door");
            player.inside = true;
            StartCoroutine(FadeCoroutine());
        }
    }

    IEnumerator FadeCoroutine()
    {
        Fade.FadeOut();
        yield return new WaitForSeconds(1f);
        Cam.target = CamMove;
        player.transform.position = target.transform.position;
        yield return new WaitForSeconds(1f);
        Fade.FadeIn();
    }
}
