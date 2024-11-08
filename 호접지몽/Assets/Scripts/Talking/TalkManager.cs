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

    public bool talking = false;

    // Start is called before the first frame update
    void Start()
    {
        count = -1;
        text.text = "";
        Name.text = "";
        Sentences = new List<string>();
        Names = new List<string>();
        sprites = new List<Sprite>();
        windows = new List<Sprite>();
    }

    public void ShowTalk(Talk t)
    {
        talking = true;

        if (Sentences.Count == 0)
        {
            for (int i = 0; i < t.sentences.Length; i++)
            {
                Names.Add(t.name[i]);
                Sentences.Add(t.sentences[i]);
                sprites.Add(t.sprites[i]);
                windows.Add(t.windows[i]);
            }
            Debug.Log(Names.Count);
        }
        animWindow.SetBool("Appear", true);
        StartCoroutine(TalkingCoroutine());
    }

    public void ExitTalk()
    {
        count = -1;
        text.text = "";
        Name.text = "";
        Names.Clear();
        Sentences.Clear();
        sprites.Clear();
        windows.Clear();
        animSprite.SetBool("Appear", false);
        animNPC.SetBool("Appear", false);
        animWindow.SetBool("Appear", false);
        talking = false;
    }

    IEnumerator TalkingCoroutine()
    {
        if (Sentences[count] == "")
        {
            count++;
        }

        Name.text += Names[count];

        if (Name.text == "»êµ¿¾Æ")
        {
            animSprite.SetBool("Appear", true);
        }
        else if(Name.text=="ÃÌÀå")
        {
            animNPC.SetBool("Appear", true);
        }

        if (count > 0)
        {
            if (windows[count] != windows[count - 1])
            {
                animSprite.SetBool("Change", true);
                animWindow.SetBool("Appear", false);
                yield return new WaitForSeconds(0.2f);
                window.GetComponent<SpriteRenderer>().sprite = windows[count];
                sprite.GetComponent<SpriteRenderer>().sprite = sprites[count];
                animWindow.SetBool("Appear", true);
                animSprite.SetBool("Change", false);
            }
            else
            {
                if (sprites[count] != sprites[count - 1])
                {
                    animSprite.SetBool("Change", true);
                    yield return new WaitForSeconds(0.1f);
                    sprite.GetComponent<SpriteRenderer>().sprite = sprites[count];
                    animSprite.SetBool("Change", false);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
        else
        {
            window.GetComponent<SpriteRenderer>().sprite = windows[count];
            sprite.GetComponent<SpriteRenderer>().sprite = sprites[count];
        }

        for(int i = 0; i < Sentences[count].Length; i++)
        {
            text.text += Sentences[count][i];
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                count++;
                text.text = "";
                Name.text = "";

                if (count == Sentences.Count)
                { 
                    StopAllCoroutines();
                    ExitTalk();
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(TalkingCoroutine());
                }
            }
        }
    }
}
