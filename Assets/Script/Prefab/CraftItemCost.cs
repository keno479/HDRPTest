using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using anogamelib;

public class CraftItemCost : MonoBehaviour
{
    public Image ItemCostIcon;
    public TextMeshProUGUI TextCost;

    public void ShowItemCost(int _item_id,int _item_cost)
    {
        MasterItemParam itemparam = DataManager.Instance.masteritem.list.Find
            (p => p.Item_ID == _item_id);
        
        ItemCostIcon.sprite = SpriteManager.Instance.Get(itemparam.Sprite_Name);
        TextCost.text = $"×{_item_cost}";
    }
    
    public bool CanCraft(int _item_id, int _item_cost)
    {
        bool ret = false;
        DataItemParam dataitem = DataManager.Instance.dataItem.list.Find
            (p => p.Item_ID == _item_id);

        if (dataitem.Num > _item_cost)
        {
            ret = true;
        }
        Debug.Log(ret);
        return ret;
    }
}
