using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedGameObject;

    private bool buttonSelectd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelectd == false)
        {
            eventSystem.SetSelectedGameObject(selectedGameObject);
            buttonSelectd = true;
        }
    }

    private void OnDisable()
    {
        buttonSelectd = false;
    }
}
