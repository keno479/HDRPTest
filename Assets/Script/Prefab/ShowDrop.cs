using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowDrop : MonoBehaviour
{
    public Image ImageDrop;
    public TextMeshProUGUI TextValue;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }
}
