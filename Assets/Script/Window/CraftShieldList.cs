using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftShieldList : MonoBehaviour
{
    private List<MasterShieldParam> Shieldlist = new List<MasterShieldParam>();
    private List<DataShieldParam> DataList = new List<DataShieldParam>();
    public Transform areaCraftShield;
    private List<GameObject> CraftList = new List<GameObject>();


    private void OnEnable()
    {
        Shieldlist = DataManager.Instance.mastershield.list;
        DataList = DataManager.Instance.datashield.list;
        

        for (int i = 0; i < Shieldlist.Count; i++)
        {
            //Debug.Log(GameDirector.Instance.CraftRecipe[i]);
            MasterShieldParam param = Shieldlist[i];

            if (!GameDirector.Instance.CraftRecipe[i] && DataList[i].Recipe_Have)
            {
                GameObject CraftShield =
                    Instantiate(PrefabHolder.Instance.CraftShield,areaCraftShield) as GameObject;
                CraftShield.GetComponent<ShieldRecipe>().CraftRecipe(param);
                GameDirector.Instance.CraftRecipe[i] = true;
            }
        }
        for (int i = 0; i < CraftList.Count; i++)
        {
            //Debug.Log("through");
            int num = i % 4;
            Button Btn = CraftList[i].GetComponent<Button>();
            Navigation Navi = Btn.navigation;
            Navi.mode = Navigation.Mode.Explicit;
            int nextIndex = i + 1;
            int preIndex = i - 1;
            if (nextIndex < CraftList.Count)
            {
                Navi.selectOnRight = CraftList[nextIndex].GetComponent<Button>();
                //Debug.Log("get");
            }

            if (preIndex >= 0)
            {
                Navi.selectOnLeft = CraftList[preIndex].GetComponent<Button>();
            }

            Btn.navigation = Navi;
        }
    }
}
