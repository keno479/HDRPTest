using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WindowStatus : MonoBehaviour
{
    public TextMeshProUGUI TextSTR;
    public TextMeshProUGUI TextVIT;
    public TextMeshProUGUI TextAGI;
    public TextMeshProUGUI TextLUK;
    public TextMeshProUGUI TextSttsPt;
    public Button BtnPlusSTR;
    public Button BtnPlusVIT;
    public Button BtnPlusAGI;
    public Button BtnPlusLUK;
    public Button BtnMinusSTR;
    public Button BtnMinusVIT;
    public Button BtnMinusAGI;
    public Button BtnMinusLUK;
    private int str;
    private int vit;
    private int agi;
    private int luk;
    private int sttsPt;

    private void OnEnable()
    {
        str = DataManager.Instance.UnitPlayer.STR;
        vit = DataManager.Instance.UnitPlayer.VIT;
        agi = DataManager.Instance.UnitPlayer.AGI;
        luk = DataManager.Instance.UnitPlayer.LUK;
        sttsPt = DataManager.Instance.UnitPlayer.StatusPoint;
        WindowUpdate();
    }

    public void STRUp()
    {
        if (sttsPt > 0)
        {
            str += 1;
            sttsPt -= 1;
        }
        WindowUpdate();
    }

    public void VITUp()
    {
        if (sttsPt > 0)
        {
            vit += 1;
            sttsPt -= 1;
        }
        WindowUpdate();
    }

    public void AGIUp()
    {
        if (sttsPt > 0)
        {
            agi += 1;
            sttsPt -= 1;
        }
        WindowUpdate();
    }

    public void LUKUp()
    {
        if (sttsPt > 0)
        {
            luk += 1;
            sttsPt -= 1;
        }
        WindowUpdate();
    }

    public void STRDown()
    {
        if(sttsPt < DataManager.Instance.UnitPlayer.StatusPoint)
        {
            str -= 1;
            sttsPt += 1;
        }
        WindowUpdate();
    }

    public void VITDown()
    {
        if (sttsPt < DataManager.Instance.UnitPlayer.StatusPoint)
        {
            vit -= 1;
            sttsPt += 1;
        }
        WindowUpdate();
    }

    public void AGIDown()
    {
        if (sttsPt < DataManager.Instance.UnitPlayer.StatusPoint)
        {
            agi -= 1;
            sttsPt += 1;
        }
        WindowUpdate();
    }

    public void LUKDown()
    {
        if (sttsPt < DataManager.Instance.UnitPlayer.StatusPoint)
        {
            luk -= 1;
            sttsPt += 1;
        }
        WindowUpdate();
    }

    public void WindowUpdate()
    {
        TextSTR.text = $"{str}";
        TextVIT.text = $"{vit}";
        TextAGI.text = $"{agi}";
        TextLUK.text = $"{luk}";
        TextSttsPt.text = $"{sttsPt,2:d} PT";
        BtnPlusSTR.interactable = sttsPt > 0;
        BtnPlusVIT.interactable = sttsPt > 0;
        BtnPlusAGI.interactable = sttsPt > 0;
        BtnPlusLUK.interactable = sttsPt > 0;
        BtnMinusSTR.interactable = sttsPt < DataManager.Instance.UnitPlayer.StatusPoint;
        BtnMinusVIT.interactable = sttsPt < DataManager.Instance.UnitPlayer.StatusPoint;
        BtnMinusAGI.interactable = sttsPt < DataManager.Instance.UnitPlayer.StatusPoint;
        BtnMinusLUK.interactable = sttsPt < DataManager.Instance.UnitPlayer.StatusPoint;
    }

    public void Decide()
    {
        DataManager.Instance.UnitPlayer.STR = str;
        DataManager.Instance.UnitPlayer.VIT = vit;
        DataManager.Instance.UnitPlayer.AGI = agi;
        DataManager.Instance.UnitPlayer.LUK = luk;
        DataManager.Instance.UnitPlayer.StatusPoint = sttsPt;
        DataManager.Instance.dataunit.Save();
        WindowUpdate();
    }
}
