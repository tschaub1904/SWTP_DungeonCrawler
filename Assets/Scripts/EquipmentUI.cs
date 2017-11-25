using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour {
    
    EquipmentManager equipment;
    public EquipmentSlotUI[] slots;

    void Start()
    {
        slots = transform.GetComponentsInChildren<EquipmentSlotUI>();

        equipment = EquipmentManager.GetInstance();
        equipment.onEquipmentChanged += UpdateUI;
    }

    private void UpdateUI(Equipment newEquip, Equipment oldEquip)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (equipment.currentEquipment[i] != null)
                slots[i].SetItem(equipment.currentEquipment[i]);
            else
                slots[i].ClearItem();
        }
    } 

}
