using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public abstract class Slottable : ScriptableObject
{
    public enum SlotType
    {
        General,
        Item,
        Skill
    };

    public string itemName = "New Slot";
    public Sprite icon;
    public SlotType type;

    protected Slottable() { }
    public abstract void Use();
}

public abstract class Slot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    
    public Slottable item { get; protected set; }

    public virtual void SetItem(Slottable newItem)
    {
        item = newItem;

        icon.enabled = true;
        icon.sprite = item.icon;
    }
    public virtual void ClearItem()
    {
        item = null;

        icon.enabled = false;
        icon.sprite = null;
    }
    public virtual bool IsEmptySlot()
    {
        return item == null;
    }
    protected virtual void SlotClicked()
    {
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount > 1)
        {
            SlotClicked();
            eventData.clickCount = 0;
        }
    }
}
