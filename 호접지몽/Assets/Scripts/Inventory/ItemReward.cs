using UnityEngine;

public class ItemUseAndReward : MonoBehaviour
{
    public int requiredItem;
    
    public Item rewardItem;
    private Inventory inventory;

    [SerializeField]
    public Talk t1;
    public Talk t2;
    private TalkManager m;
    private AudioManager a;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        m = FindObjectOfType<TalkManager>();
        a = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (inventory.HasItem(requiredItem))
            {
                inventory.UseItem(requiredItem);
                inventory.AddItem(rewardItem);

                a.Play("Press");
                m.ShowTalk(t1);
                Destroy(this.gameObject);
            }
            else
            {
                m.ShowTalk(t2);
                Debug.Log("필요한 아이템이 없습니다! 아이템을 먼저 구하세요.");
            }
        }
    }
}
