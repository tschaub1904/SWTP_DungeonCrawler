using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    private static EquipmentManager instance;
    public static EquipmentManager GetInstance()
    {
        return instance;
    }

    void Awake() {
        if (instance == null)
            instance = this;
    }
    #endregion

    public Equipment[] currentEquipment { get; private set; }

    public delegate void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip);
    public OnEquipmentChanged onEquipmentChanged;

    void Start()
    {
        int numSlots = Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newEquipment)
    {
        int slot = (int)newEquipment.equipmentSlot;

        if (!EmptySlot(slot))
            Inventory.GetInstance().AddItem(currentEquipment[slot]);

        currentEquipment[slot] = newEquipment;
        onEquipmentChanged(newEquipment, null);
    }

    public void Unequip(Equipment oldEquipment)
    {
        int slot = (int)oldEquipment.equipmentSlot;

        if (!EmptySlot(slot))
            Inventory.GetInstance().AddItem(currentEquipment[slot]);

        currentEquipment[slot] = null;
        onEquipmentChanged(null, oldEquipment);
    }


    bool EmptySlot(int slot)
    {
        return currentEquipment[slot] == null;
    }
    bool EmptySlot(EquipmentSlot slot)
    {
        return EmptySlot((int)slot);
    }
}
