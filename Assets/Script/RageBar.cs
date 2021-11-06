using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.maxValue = 5;
        slider.value = RageTimer.timeRemaining;
    }
    void Update()
    {
        slider.value = RageTimer.timeRemaining;
    }
}
