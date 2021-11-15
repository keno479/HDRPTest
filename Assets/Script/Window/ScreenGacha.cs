using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using anogamelib;

public class ScreenGacha : MonoBehaviour
{
    public Button GachaEquip1Button;
    public Button GachaEquip10Button;
    public Button GachaItem1Button;
    public Button GachaItem10Button;
    public TextMeshProUGUI GoldText_Gacha;
    public TextMeshProUGUI StoneText_Gacha;
    public Image EquipResult;
    public Image[] EquipResult10;
    public Image ItemResult;
    public Image[] ItemResult10;

    private void OnEnable()
    {
        GachaEquip_On();
        GachaItem_On();
        //GameDirector.Instance.ShowGold(DataManager.Instance.GameInfo.GetInt(Define.KeyGold));
        //GameDirector.Instance.ShowStone(DataManager.Instance.GameInfo.GetInt(Define.KeyStone));
        GoldText_Gacha.text = GameDirector.Instance.GoldText.text;
        StoneText_Gacha.text = GameDirector.Instance.StoneText.text;
    }
    private void Awake()
    {
        
    }

    public void GachaEquip(int count)
    {
        DataManager.Instance.GameInfo.AddInt(Define.KeyStone, Define.EquipGachaCost * count * -1);
        for (int i = 0; i < count; i++)
        {
            MasterWeaponParam GachaResult = UtilRand.GetParam(ref DataManager.Instance.masterweapon.list, "Gacha_Prob");
            //Debug.Log(GachaResult.Weapon_Name);
            DataManager.Instance.dataWeapon.Add(GachaResult.Weapon_ID);
            EquipResult.sprite = SpriteManager.Instance.Get(GachaResult.Sprite_Name);
            EquipResult10[i].sprite = SpriteManager.Instance.Get(GachaResult.Sprite_Name);
        }
        DataManager.Instance.dataWeapon.list.Sort((a, b) => a.Weapon_ID - b.Weapon_ID);
        DataManager.Instance.dataWeapon.Save();
        GachaEquip_On();
        GameDirector.Instance.ShowStone(DataManager.Instance.GameInfo.GetInt(Define.KeyStone));
        StoneText_Gacha.text = GameDirector.Instance.StoneText.text;
        DataManager.Instance.GameInfo.Save();
    }

    public void GachaItem(int count)
    {
        int Gold=DataManager.Instance.GameInfo.AddInt(Define.KeyGold, Define.ItemGachaCost * count * -1);
        //Debug.Log(Gold);
        for (int i = 0; i < count; i++)
        {
            MasterItemParam GachaResult = UtilRand.GetParam(ref DataManager.Instance.masteritem.list, "Gacha_Prob");
            //Debug.Log(GachaResult.Item_Name);
            DataManager.Instance.dataItem.Add(GachaResult.Item_ID);
            ItemResult.sprite = SpriteManager.Instance.Get(GachaResult.Sprite_Name);
            ItemResult10[i].sprite = SpriteManager.Instance.Get(GachaResult.Sprite_Name);
        }
        DataManager.Instance.dataItem.list.Sort((a, b) => a.Item_ID - b.Item_ID);
        DataManager.Instance.dataItem.Save();
        GachaItem_On();
        GameDirector.Instance.ShowGold(DataManager.Instance.GameInfo.GetInt(Define.KeyGold));
        GoldText_Gacha.text = GameDirector.Instance.GoldText.text;
        DataManager.Instance.GameInfo.Save();
    }

    public void GachaEquip_On()
    {
        GachaEquip1Button.interactable = Define.EquipGachaCost <= DataManager.Instance.GameInfo.GetInt(Define.KeyStone);
        GachaEquip10Button.interactable = Define.EquipGachaCost * 10 <= DataManager.Instance.GameInfo.GetInt(Define.KeyStone);
    }
    public void GachaItem_On()
    {
        GachaItem1Button.interactable = Define.ItemGachaCost <= DataManager.Instance.GameInfo.GetInt(Define.KeyGold);
        GachaItem10Button.interactable = Define.ItemGachaCost * 10 <= DataManager.Instance.GameInfo.GetInt(Define.KeyGold);
    }
}
