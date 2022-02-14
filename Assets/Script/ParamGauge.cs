using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParamGauge : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private Slider slider
    {
        get { return GetComponent<Slider>(); }
    }

    public void Set(int Value)
    {
        slider.value = Value;
        text.text = $"{Value}/{slider.maxValue}";
    }

    public void Init(int Value,int Max)
    {
        slider.maxValue = Max;
        Set(Value);
    }
}
