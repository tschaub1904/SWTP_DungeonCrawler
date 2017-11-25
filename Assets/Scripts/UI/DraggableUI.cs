using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IDragHandler, IBeginDragHandler {

    public Transform parentUI;

    Vector2 distance;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button != PointerEventData.InputButton.Left)
            return;

        distance = eventData.position - (Vector2)parentUI.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        parentUI.position = eventData.position - distance;
    }
}
