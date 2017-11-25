using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    private static Inventory instance = null;
    public static Inventory GetInstance()
    {
        return instance;
    }

    #endregion

    public Equipment testItem;

    public List<Item> items = new List<Item>();
    public int maxItemCount = 9;

    public delegate void OnInventoryChanged(Item newItem, Item oldItem);
    public OnInventoryChanged onInventoryChanged;

    void Awake()
    {   
        if (instance == null)
            instance = this;
    }

    public void AddItem(Item newItem)
    {
        if (items.Count >= maxItemCount)
            return;

        items.Add(newItem);
        onInventoryChanged(newItem, null);
    }

    public void RemoveItem(Item itemToRemove)
    {
        int itemIndex = items.IndexOf(itemToRemove);
        if (itemIndex < 0)
            return;

        items.RemoveAt(itemIndex);
        onInventoryChanged(null, itemToRemove);
    }
}
