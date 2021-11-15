using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowQuestList : MonoBehaviour
{
    public Transform areaQuest;
    private List<MasterQuestParam> QuestList = new List<MasterQuestParam>();

    private void OnEnable()
    {
        QuestList = DataManager.Instance.masterquest.list;

        Delete();
        for (int i = 0; i < QuestList.Count; i++)
        {
            GameObject Quest = Instantiate(PrefabHolder.Instance.Quest,areaQuest.transform) as GameObject;
            Quest.GetComponent<Quest>().SetQuest(QuestList[i]);
        }
    }
    public void Delete()
    {
        //Debug.Log(GetComponentsInChildren<Quest>().Length);
        //GetComponentsInChildren<Quest>();
        foreach (Quest tr in GetComponentsInChildren<Quest>())
        {
            //Debug.Log(tr);
            Destroy(tr.gameObject);
        }
    }
}
