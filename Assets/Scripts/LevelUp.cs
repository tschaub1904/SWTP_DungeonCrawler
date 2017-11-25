using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {

    public static int level;


    Text text;


    void Awake()
    {
        text = GetComponent<Text>();
        level = 1;
    }


    void Update()
    {
        text.text = "Level: " + level;
    }
}
