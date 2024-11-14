using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Text Name;
    public Text text;
    public SpriteRenderer sprite;
    public SpriteRenderer window;

    private List<string> Names;
    private List<string> Sentences;
    private List<Sprite> sprites;
    private List<Sprite> NPCs;
    private List<Sprite> windows;

    private int count;

    public Animator animSprite;
    public Animator animNPC;
    public Animator animWindow;

    private MovingObject p;

    bool talking;
    public bool a=false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        text.text = "";
        Name.text = "";
        Sentences = new List<string>();
        Names = new List<string>();
        //sprites = new List<Sprite>();
        //windows = new List<Sprite>();
        talking = false;
        p = FindObjectOfType<MovingObject>();
    }


    public void ShowTalk(Talk t)
    {
        talking = true;

        if (Names.Count <= 0)
        {
            for (int i = 0; i < t.sentences.Length; i++)
            {
                Names.Add(t.name[i]);
                Sentences.Add(t.sentences[i]);
                //sprites.Add(t.sprites[i]);
                //windows.Add(t.windows[i]);
            }
        }
        animWindow.SetBool("Appear", true);
        StartCoroutine(TalkingCoroutine());
    }

    public void ExitTalk()
    {
        count = 0;
        text.text = "";
        Name.text = "";
        Names.Clear();
        Sentences.Clear();
        //sprites.Clear();
        //windows.Clear();
        animSprite.SetBool("Appear", false);
        animSprite.SetBool("Change", false);
        animNPC.SetBool("Appear", false);
        animNPC.SetBool("Change", false);
        animWindow.SetBool("Appear", false);
        talking = false;
    }

    IEnumerator TalkingCoroutine()
    {
        a = true;
        Name.text += Names[count];

        if (Name.text == "»êµ¿¾Æ")
        {
            Debug.Log("1");
            animSprite.SetBool("Change", false);
            animSprite.SetBool("Appear", true);
            animNPC.SetBool("Appear", false);
        }
        else if(Name.text=="ÃÌÀå")
        {
            animNPC.SetBool("Change", false);
            animNPC.SetBool("Appear", true);
            animSprite.SetBool("Change", true);
        }
        else
        {
            animSprite.SetBool("Change", true);
        }

        //if (count > 0)
        //{
        //    if (windows[count] != windows[count - 1])
        //    {
        //        animSprite.SetBool("Change", true);
        //        animWindow.SetBool("Appear", false);
        //        yield return new WaitForSeconds(0.2f);
        //        window.GetComponent<SpriteRenderer>().sprite = windows[count];
        //        sprite.GetComponent<SpriteRenderer>().sprite = sprites[count];
        //        animWindow.SetBool("Appear", true);
        //        animSprite.SetBool("Change", false);
        //    }
        //    else
        //    {
        //        if (sprites[count] != sprites[count - 1])
        //        {
        //            animSprite.SetBool("Change", true);
        //            yield return new WaitForSeconds(0.1f);
        //            sprite.GetComponent<SpriteRenderer>().sprite = sprites[count];
        //            animSprite.SetBool("Change", false);
        //        }
        //        else
        //        {
        //            yield return new WaitForSeconds(0.05f);
        //        }
        //    }
        //}
        //else
        //{
        //    window.GetComponent<SpriteRenderer>().sprite = windows[count];
         //   sprite.GetComponent<SpriteRenderer>().sprite = sprites[count];
        //}

        for(int i = 0; i < Sentences[count].Length; i++)
        {
            text.text += Sentences[count][i];
            yield return new WaitForSeconds(0.05f);
        }
        a = false;
    }

   // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            p.StopMove();
            if (Input.GetKeyDown(KeyCode.C)&&!a)
            {
                count++;
                text.text = "";
                Name.text = "";
                if (count == Names.Count)
                {
                    StopAllCoroutines();
                    p.CanMove();
                    ExitTalk();
                }
                else// if (count !=1)
                {
                    StartCoroutine(TalkingCoroutine());
                }
            }
        }
    }
}
