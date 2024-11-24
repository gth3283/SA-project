using UnityEngine;

public class ItemPick : MonoBehaviour
{
    public Item pickItem; // 아이템 정보(아이템의 종류나 속성 등)를 담은 변수

    private Inventory inventory;
    [SerializeField]
    public Talk t;
    private TalkManager m;
    private MovingObject p;
    private AudioManager a;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>(); 
        m = FindObjectOfType<TalkManager>();  
        a = FindObjectOfType<AudioManager>();  
        p = FindObjectOfType<MovingObject>(); 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            inventory.AddItem(pickItem);

            a.Play("Press");
            m.ShowTalk(t);

            Destroy(this.gameObject);
        }
    }
}
