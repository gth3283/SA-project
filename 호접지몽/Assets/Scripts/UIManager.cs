using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Inventory;
    private UIManager instance = null;
    private MovingObject player;

    private void Awake()
    {
        if(instance == null)
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
        Inventory = GameObject.Find("Inventory");
        player = FindObjectOfType<MovingObject>();
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.activeSelf)
            {
                Inventory.SetActive(false);
                player.CanMove();
            }
            else
            {
                Inventory.SetActive(true);
                player.StopMove();
            }
        }
    }
}
