using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;
using UnityEngine.UI;

public class ItemWindow : Singleton<ItemWindow>
{
    public List<ItemIcon> ItemIconList;
    private void OnEnable()
    {
        ShowItem();
    }

    public void ShowItem()
    {
        foreach (ItemIcon icon in ItemIconList)
        {
            int Item_ID = icon.GetItemID();
            DataItemParam param =
                DataManager.Instance.dataItem.list.Find(p => p.Item_ID == Item_ID);
            icon.Init(param);
            Image IconImage = icon.GetItemImage();
            MasterItemParam iconimage =
                DataManager.Instance.masteritem.list.Find(p => p.Item_ID == Item_ID);
            IconImage.sprite = SpriteManager.Instance.Get(iconimage.Sprite_Name);
            //Debug.Log(iconimage.Item_ID);
        }
    }
}
