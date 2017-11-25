using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemPickup : MonoBehaviour {

    public Item item;
    public bool isAutoPickup = false;
    public float autoPickupDistance = 0.5f;

    Transform playerReference;
    
	// Use this for initialization
	void Start () {
        //this.tag = "Interactable";

        this.GetComponent<SpriteRenderer>().sprite = item.icon;

        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
	}
    private void Update()
    {
        
        if (isAutoPickup)
        {
            float distance = (transform.position - playerReference.position).magnitude;
            if (distance < autoPickupDistance)
                Interact();
        }
    }

    public void Interact()
    {
        Inventory.GetInstance().AddItem(item);
        Destroy(this.gameObject);
    }
}
