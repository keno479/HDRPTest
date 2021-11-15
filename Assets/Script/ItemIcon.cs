using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemIcon : MonoBehaviour
{
    [SerializeField]
    private int Item_ID;
    public Image IconImage;
    public TextMeshProUGUI Num;
    
    public void Init(DataItemParam Data)
    {
        int num = 0;
        if (Data != null)
        {
            num = Data.Num;
        }
        Num.text = $"×{num}";
    }
    
    public int GetItemID()
    {
        return Item_ID;
    }

    public Image GetItemImage()
    {
        return IconImage;
    }
}
