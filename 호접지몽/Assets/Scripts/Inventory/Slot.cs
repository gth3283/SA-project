using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;

    public GameObject ItemText;
    public Text NameText;
    public Text DescriptionText;
    private Inventory inventory;
    private Item _item;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        ItemText.SetActive(false);
    }

    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
                image.color = new Color(1, 1, 1, 0);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click Item");
        if (_item != null)
        {
            inventory.UseItem(_item.itemID);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Pointer Enter");
        NameText.text = _item.itemName;
        DescriptionText.text = _item.itemDescription;
        ItemText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        ItemText.SetActive(false);
    }
}
