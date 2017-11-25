using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : Slot, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    public Transform slotDummy;
    
    public CanvasGroup canvasGroup { get; private set; }
    public Button button;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void SetItem(Slottable newItem)
    {
        base.SetItem(newItem);
        button.interactable = true;
    }
    public override void ClearItem()
    {
        base.ClearItem();
        button.interactable = false;
    }
    protected override void SlotClicked()
    {
        item.Use();
    }


    #region Drag & Drop

    InventorySlot dummy;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (IsEmptySlot())
            return;

        dummy = Instantiate(slotDummy, transform.parent.parent.parent.parent).GetComponent<InventorySlot>();
        dummy.SetItem(item);
        dummy.GetComponent<CanvasGroup>().blocksRaycasts = false;
        dummy.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta * .8f;
        dummy.canvasGroup.alpha = 0.75f;

        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsEmptySlot())
            return;

        dummy.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dummy == null)
            return;

        Destroy(dummy.gameObject);
        dummy = null;
        canvasGroup.alpha = 1f;
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventorySlot drop = eventData.pointerDrag.GetComponent<InventorySlot>();
        if (drop.IsEmptySlot())
            return;

        Debug.Log(drop + " was dropped onto " + this.name);
        
        Slottable droppedItem = drop.item;

        if (this.IsEmptySlot())
            drop.ClearItem();
        else
            drop.SetItem(this.item);

        this.SetItem(droppedItem);

    }

    #endregion

}
