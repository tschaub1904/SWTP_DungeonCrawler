using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item", fileName = "New Item")]
public class Item : Slottable {
    public Item CreateInstance()
    {
        Item newItem = ScriptableObject.CreateInstance<Item>(); 
        newItem.itemName = this.itemName;
        newItem.icon = this.icon;
        newItem.type = this.type;
        return newItem;
    }

    public override void Use()
    {
        Debug.Log("(Item): " + itemName + " was used.");
    }

    public void RemoveFromInventory()
    {
        Inventory.GetInstance().RemoveItem(this);
    }
}
