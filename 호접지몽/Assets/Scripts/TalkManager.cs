using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public Text text;
    public SpriteRenderer sprite;
    public SpriteRenderer window;

    public List<string> Sentences;
    public List<Sprite> sprites;
    public List<Sprite> windows;

    private int count;

    public Animator animSprite;
    public Animator animWindow;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        text.text = "";
        Sentences = new List<string>();
        sprites = new List<Sprite>();
        windows = new List<Sprite>();
    }

    public void ShowTalk(Talk t)
    {
        for(int i=0;i<t.sentences.Length;i++)
        {
            Sentences.Add(t.sentences[i]);
            sprites.Add(t.sprites[i]);
            windows.Add(t.windows[i]);
        }
        animSprite.SetBool("Appear", true);
        animWindow.SetBool("Appear", true);
        StartCoroutine(TalkingCoroutine());
    }

    IEnumerator TalkingCoroutine()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
