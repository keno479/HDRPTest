using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftShieldList : MonoBehaviour
{
    private List<MasterShieldParam> Shieldlist = new List<MasterShieldParam>();
    private List<DataShieldParam> DataList = new List<DataShieldParam>();
    public Transform areaCraftShield;


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
    }
}
