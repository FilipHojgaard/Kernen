using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shieldbar : MonoBehaviour
{

    public Slider slider;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void setShield(float value) {
        slider.value = value;
    }

    public void setMaxShield(float value) {
        slider.maxValue = value;
        slider.value = value;
    }
}
