using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamGauge : MonoBehaviour
{
    private Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    public void Set(int Value)
    {
        slider.value = Value;
    }

    public void Init(int Value,int Max)
    {
        slider.maxValue = Max;
        Set(Value);
    }
}
