using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;

#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif

    private void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot() //아이템 슬롯 정리
    {
        int i = 0;
        for(; i < items.Count && i < slots.Length; i++)
            slots[i].item = items[i];
        for(; i < slots.Length; i++)
            slots[i].item = null;
    }

    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            Debug.Log(_item.itemName + " added to inventory.");  // 아이템이 추가될 때 로그 출력
            FreshSlot();
        }
    }

    public void UseItem(int itemID)
    {
        if(items.Count > 0)
        {
            int findItem = items.FindIndex(item => item.itemID.Equals(itemID)); //일치하는 값을 찾으면 인덱스 리턴, 없으면 -1
            if (findItem != -1)
            {
                items.RemoveAt(findItem);
                FreshSlot();
                return;
            }
        }
    }

    public bool HasItem(int itemID)
    {
        return items.Any(item => item.itemID == itemID);  
    }
}
