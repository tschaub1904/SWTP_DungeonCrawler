using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour {

    public Slider volume;

    void Update()
    {
        AudioListener.volume = volume.value;
    }
}
