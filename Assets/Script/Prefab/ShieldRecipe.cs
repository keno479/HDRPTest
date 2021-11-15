using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using anogamelib;

public class ShieldRecipe : MonoBehaviour
{
    public TextMeshProUGUI Shield_Name;
    public TextMeshProUGUI TextCostGold;
    public Image ShieldIcon;
    public Transform areaItemCost;
    public GameObject Complete;
    public Button BtnCraft;
    [SerializeField]
    private int Shield_ID;

    public void CraftRecipe(MasterShieldParam _param)
    {
        DataShieldParam datashield = DataManager.Instance.datashield.list.Find
            (p => p.Shield_ID == _param.Shield_ID);
        Shield_ID = _param.Shield_ID;

        ShieldIcon.sprite = SpriteManager.Instance.Get(_param.Sprite_Name);
        Shield_Name.text = $"{_param.Shield_Name}";
        TextCostGold.text = $"{_param.Craft_Gold_Cost}";
        
        int[] Craft_Item_IDs = new int[]
        {
            _param.Craft_Item_ID1,
            _param.Craft_Item_ID2,
            _param.Craft_Item_ID3,
        };
        int[] Craft_Item_Cost = new int[]
        {
            _param.Craft_Item1_Value,
            _param.Craft_Item2_Value,
            _param.Craft_Item3_Value,
        };

        for (int i = 0; i < Craft_Item_IDs.Length; i++)
        {
            if (Craft_Item_Cost[i] > 0)
            {
                GameObject CraftItem = Instantiate(PrefabHolder.Instance.CraftItem,areaItemCost) as GameObject;
                CraftItem.GetComponent<CraftItemCost>().
                    ShowItemCost(Craft_Item_IDs[i], Craft_Item_Cost[i]);
            }
        }

        Have(datashield.Have);
    }

    public void Have(bool _have)
    {
        if (_have)
        {
            Complete.SetActive(true);
            BtnCraft.interactable = false;
        }
    }

    public void Craft()
    {
        bool itemcost_bool = false;
        DataShieldParam dataparam =
            DataManager.Instance.datashield.list.Find(p => p.Shield_ID == Shield_ID);
        MasterShieldParam masterparam =
            DataManager.Instance.mastershield.list.Find(p => p.Shield_ID == Shield_ID);
       
        int[] Craft_Item_IDs = new int[]
        {
            masterparam.Craft_Item_ID1,
            masterparam.Craft_Item_ID2,
            masterparam.Craft_Item_ID3,
        };
        int[] Craft_Item_Cost = new int[]
        {
            masterparam.Craft_Item1_Value,
            masterparam.Craft_Item2_Value,
            masterparam.Craft_Item3_Value,
        };

        for (int i = 0; i < Craft_Item_IDs.Length; i++)
        {
            DataItemParam dataitem = DataManager.Instance.dataItem.list.Find
                (p => p.Item_ID == Craft_Item_IDs[i]);

            if (dataitem.Num >= Craft_Item_Cost[i])
            {
                itemcost_bool = true;
            }
            else
            {
                itemcost_bool = false;
            }

            if (!itemcost_bool)
            {
                break;
            }
        }

        if (DataManager.Instance.GameInfo.GetInt(Define.KeyGold) >
            masterparam.Craft_Gold_Cost && itemcost_bool)
        {
            DataManager.Instance.datashield.Add(Shield_ID);
            DataManager.Instance.GameInfo.AddInt(Define.KeyGold, masterparam.Craft_Gold_Cost * -1);
            for (int i = 0; i < Craft_Item_IDs.Length; i++)
            {
                DataItemParam dataitem = DataManager.Instance.dataItem.list.Find
                    (p => p.Item_ID == Craft_Item_IDs[i]);

                dataitem.Num -= Craft_Item_Cost[i];
            }
            Have(dataparam.Have);
            DataManager.Instance.GameInfo.Save();
            DataManager.Instance.dataItem.Save();
        }
        //Debug.Log(itemcost_bool);
    }
}