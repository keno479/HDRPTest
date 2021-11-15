using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using anogamelib;

public class WindowShield : MonoBehaviour
{
    public GameObject areaR;
    public GameObject areaL;
    public Image ImageShieldR;
    public Image ImageShieldL;
    public Image MainShieldImage;
    public Button ButtonEquip;
    public TextMeshProUGUI Shield_Name;
    public TextMeshProUGUI Defense;
    public TextMeshProUGUI PageNum;
    private List<MasterShieldParam> ShieldList = new List<MasterShieldParam>();
    private int Shield_ID;
    private int ShieldIndex;

    private void OnEnable()
    {
        Shield_ID = DataManager.Instance.GameInfo.GetInt(Define.KeyEquipShieldID);
        MasterShieldParam mastershield = DataManager.Instance.mastershield.list.Find(p => p.Shield_ID == Shield_ID);
        ShieldList = DataManager.Instance.mastershield.list;
        ShieldIndex = ShieldList.IndexOf(mastershield);
        ShowShield(ShieldIndex);
    }

    public void EpuipButton()
    {
        DataManager.Instance.GameInfo.SetInt(Define.KeyEquipShieldID, Shield_ID);
        DataManager.Instance.GameInfo.Save();
    }

    public void MoveR()
    {
        ShieldIndex += 1;
        ShowShield(ShieldIndex);
    }

    public void MoveL()
    {
        ShieldIndex -= 1;
        ShowShield(ShieldIndex);
    }

    public void ShowShield(int _index)
    {
        Shield_ID = ShieldList[ShieldIndex].Shield_ID;
        MasterShieldParam mastershield = 
            DataManager.Instance.mastershield.list.Find(p => p.Shield_ID == Shield_ID);
        DataShieldParam datashield = 
            DataManager.Instance.datashield.list.Find(p => p.Shield_ID == mastershield.Shield_ID);


        if (datashield == null || !datashield.Have)
        {
            MainShieldImage.sprite = SpriteManager.Instance.Get("Bonus_50");
            Defense.text = "防御力:??";
            Shield_Name.text = "???";
            //Debug.Log(datashield);
        }
        else
        {
            MainShieldImage.sprite = SpriteManager.Instance.Get(mastershield.Sprite_Name);
            Defense.text = $"防御力:{mastershield.Defense}";
            Shield_Name.text = $"{mastershield.Shield_Name}";
            //Debug.Log(mastershield.Sprite_Name);
        }
        ButtonEquip.interactable = datashield != null;
        PageNum.text = $"{ShieldIndex + 1}/{ShieldList.Count}";
        ShowSideShield(areaR, ImageShieldR, _index + 1);
        ShowSideShield(areaL, ImageShieldL, _index - 1);
    }

    public void ShowSideShield(GameObject _area,Image _sideshield,int _shield_index)
    {
        if (_shield_index >= 0 && _shield_index < ShieldList.Count)
        {
            MasterShieldParam mastershield =
                DataManager.Instance.mastershield.list.Find(p => p.Shield_ID == ShieldList[_shield_index].Shield_ID);
            DataShieldParam datashield =
                DataManager.Instance.datashield.list.Find(p => p.Shield_ID == mastershield.Shield_ID);
            
            if(datashield == null || !datashield.Have)
            {
                _sideshield.sprite = SpriteManager.Instance.Get("Bonus_50");
            }
            else
            {
                _sideshield.sprite = SpriteManager.Instance.Get(mastershield.Sprite_Name);
            }
            _area.SetActive(true);
        }
        else
        {
            _area.SetActive(false);
        }
    }
}
