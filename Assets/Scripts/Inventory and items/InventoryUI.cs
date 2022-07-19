using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryUI;

    public MouseLook mouseLook;
    
    public Transform itemsParent;
    private Inventory inventory;
    private InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryUI.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                mouseLook.enabled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                mouseLook.enabled = false;
            }
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    
}
