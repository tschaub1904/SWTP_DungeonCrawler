using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUI : Slot
{
    public Text itemText;

    void Awake()
    {
        icon.sprite = null;
    }

    public override void SetItem(Slottable newItem)
    {
        base.SetItem(newItem);
        itemText.text = newItem.itemName;
    }

    public override void ClearItem()
    {
        base.ClearItem();
        itemText.text = "leer";
    }

    protected override void SlotClicked()
    {
        Debug.Log("Equipment Slot Clicked");
        EquipmentManager.GetInstance().Unequip((Equipment)item);
    }
}