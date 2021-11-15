using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using anogamelib;

public class WeaponWindow : MonoBehaviour
{
    private int Weapon_ID;
    private List<MasterWeaponParam> WeaponList = new List<MasterWeaponParam>();
    public TextMeshProUGUI WeaponNameText;
    public Image MainWeaponImage;
    public GameObject AreaRight;
    public GameObject AreaLeft;
    public Image RWeaponImage;
    public Image LWeaponImage;
    public Image CraftItemImage;
    public TextMeshProUGUI WeaponStatus;
    public Button EquipButton;
    public Button LVUpButton;
    public TextMeshProUGUI GoldCost;
    public TextMeshProUGUI ItemCost;
    public TextMeshProUGUI LackText;
    public TextMeshProUGUI PageNum;
    private int WeaponIndex;

    private void OnEnable()
    {
        Weapon_ID = DataManager.Instance.GameInfo.GetInt(Define.KeyEquipWeaponID);
        MasterWeaponParam param = 
            DataManager.Instance.masterweapon.list.Find(p => p.Weapon_ID == Weapon_ID);
        WeaponList = DataManager.Instance.masterweapon.list;
        WeaponIndex = WeaponList.IndexOf(param);
        ShowWeapon(WeaponIndex);
    }

    public void EpuipButton()
    {
        DataManager.Instance.GameInfo.SetInt(Define.KeyEquipWeaponID, WeaponList[WeaponIndex].Weapon_ID);
        DataManager.Instance.GameInfo.Save();
    }

    public void LButton()
    {
        WeaponIndex -= 1;
        ShowWeapon(WeaponIndex);
    }

    public void RButton()
    {
        WeaponIndex += 1;
        ShowWeapon(WeaponIndex);
    }

    public void ShowWeapon(int _index)
    {
        MasterWeaponParam SelectedWeapon =
            DataManager.Instance.masterweapon.list.Find(p => p.Weapon_ID == WeaponList[_index].Weapon_ID);
        DataWeaponParam weapondata =
            DataManager.Instance.dataWeapon.list.Find(p => p.Weapon_ID == SelectedWeapon.Weapon_ID);
        MasterItemParam CraftItem =
            DataManager.Instance.masteritem.list.Find(p => p.Item_ID == SelectedWeapon.Craft_Item_ID);

        PageNum.text = $"{_index + 1,2:d}/{WeaponList.Count}";
        if (weapondata != null)
        {
            MainWeaponImage.sprite = SpriteManager.Instance.Get(SelectedWeapon.Sprite_Name);
            WeaponStatus.text =
                $"LV{weapondata.Weapon_LV}(+{weapondata.Num - 1})\n攻撃力:{SelectedWeapon.Attack + weapondata.Weapon_LV - 1}(+{weapondata.Num - 1})";
            CraftItemImage.sprite = SpriteManager.Instance.Get(CraftItem.Sprite_Name);
            WeaponNameText.text = $"{SelectedWeapon.Weapon_Name}";
            GoldCost.text = $"{weapondata.Weapon_LV * 100}";
            ItemCost.text = $"{weapondata.Weapon_LV}";
        }
        else
        {
            MainWeaponImage.sprite = SpriteManager.Instance.Get("Bonus_50");
            WeaponStatus.text = "LV?(+?)\n攻撃力:??(+?)";
            CraftItemImage.sprite = SpriteManager.Instance.Get("Bonus_50");
            WeaponNameText.text = "???";
            GoldCost.text = "???";
            ItemCost.text = "?";
        }
        EquipButton.interactable = weapondata != null;

        ShowSideWeapon(_index + 1, AreaRight, RWeaponImage);
        ShowSideWeapon(_index - 1, AreaLeft, LWeaponImage);
        LVUpButton.interactable = weapondata != null && 
            NeedItem(SelectedWeapon.Craft_Item_ID, weapondata.Weapon_LV) && NeedGold(weapondata.Weapon_LV * 100);
    }

    private void ShowSideWeapon(int _index,GameObject _Area,Image _Icon)
    {
        if (_index >= 0 && _index < WeaponList.Count)
        {
            MasterWeaponParam master =
               DataManager.Instance.masterweapon.list.Find(p => p.Weapon_ID == WeaponList[_index].Weapon_ID);
            DataWeaponParam data =
                DataManager.Instance.dataWeapon.list.Find(p => p.Weapon_ID == master.Weapon_ID);

            if (data != null)
            {
                _Icon.sprite = SpriteManager.Instance.Get(master.Sprite_Name);
            }
            else
            {
                _Icon.sprite = SpriteManager.Instance.Get("Bonus_50");
            }
            _Area.SetActive(true);
        }
        else
        {
            _Area.SetActive(false);
        }
    }

    public void WeaponLVUp()
    {
        MasterWeaponParam param =
            DataManager.Instance.masterweapon.list.Find(p => p.Weapon_ID == WeaponList[WeaponIndex].Weapon_ID);
        DataWeaponParam data =
            DataManager.Instance.dataWeapon.list.Find(p => p.Weapon_ID == param.Weapon_ID);
        DataItemParam dataitem =
            DataManager.Instance.dataItem.list.Find(p => p.Item_ID == param.Craft_Item_ID);

        if (!NeedItem(param.Craft_Item_ID, data.Weapon_LV))
        {
            LackItem();
        }
        else if (!NeedGold(data.Weapon_LV * 100))
        {
            LackGold();
        }
        else
        {
            DataManager.Instance.GameInfo.AddInt(Define.KeyGold, data.Weapon_LV * -100);
            dataitem.Num -= data.Weapon_LV;
            data.Weapon_LV += 1;
            GameDirector.Instance.ShowGold(DataManager.Instance.GameInfo.GetInt(Define.KeyGold));
            ShowWeapon(WeaponIndex);
            DataManager.Instance.GameInfo.Save();
            DataManager.Instance.dataItem.Save();
            DataManager.Instance.dataWeapon.Save();
        }
        //Debug.Log(WeaponIndex);
    }

    public bool NeedItem(int _CraftItemID,int _CraftItemNum)
    {
        bool ret = false;
        DataItemParam dataitem = 
            DataManager.Instance.dataItem.list.Find(p => p.Item_ID == _CraftItemID);
        ret = (_CraftItemNum <= dataitem.Num);
        return ret;
    }

    public bool NeedGold(int _GoldValue)
    {
        bool ret = false;
        ret = (_GoldValue <= DataManager.Instance.GameInfo.GetInt(Define.KeyGold));
        return ret;
    }
    public void LackItem()
    {
        //Debug.Log("アイテムが不足しています");
        LackText.text = "アイテムが不足しています";
    }

    public void LackGold()
    {
        //Debug.Log("ゴールドが不足しています");
        LackText.text = "ゴールドが不足しています";
    }
}
