using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Items/Equipment")]
public class Equipment : Item {
    public EquipmentSlot equipmentSlot = EquipmentSlot.Armour;
    public new Equipment CreateInstance()
    {
        Equipment newEquipment = ScriptableObject.CreateInstance<Equipment>();
        newEquipment.itemName = this.itemName;
        newEquipment.icon = this.icon;
        newEquipment.type = this.type;
        newEquipment.equipmentSlot = this.equipmentSlot;
        return newEquipment;
    }
    public override void Use()
    {
        base.Use();
        RemoveFromInventory();
        EquipmentManager.GetInstance().Equip(this);
    }
}

public enum EquipmentSlot
{
    Armour,
    Weapon,
    Accessory
}