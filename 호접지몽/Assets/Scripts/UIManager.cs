using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject Inventory;

    // Start is called before the first frame update
    void Start()
    {
        Inventory = GameObject.Find("Inventory");
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.activeSelf)
                Inventory.SetActive(false);
            else
                Inventory.SetActive(true);
        }
    }
}
