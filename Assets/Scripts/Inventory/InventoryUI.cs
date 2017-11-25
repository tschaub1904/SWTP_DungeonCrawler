using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    private Inventory inventory;
    public GameObject inventoryUI;
    public Transform inventorySlotContainer;
    
    public InventorySlot[] slots;
    
	void Start () {
        inventory = Inventory.GetInstance();
        inventory.onInventoryChanged += UpdateUI;

        slots = inventorySlotContainer.GetComponentsInChildren<InventorySlot>();
	}

    void UpdateUI(Item newItem, Item oldItem)
    {
        if (newItem != null)
            AddItemToUI(newItem);
        else if (oldItem != null)
            RemoveItemFromUI(oldItem);
    }

    void AddItemToUI(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].IsEmptySlot())
            {
                slots[i].SetItem(item);
                return;
            }
        }
    }
    void RemoveItemFromUI(Item item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (item == slot.item)
            {
                slot.ClearItem();
                return;
            }
        }
    }


    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
