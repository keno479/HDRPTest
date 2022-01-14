using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowQuestList : MonoBehaviour
{
    public Transform areaQuest;
    private List<MasterQuestParam> QuestList = new List<MasterQuestParam>();
    private List<GameObject> BtnQuestList = new List<GameObject>();

    private void OnEnable()
    {
        QuestList = DataManager.Instance.masterquest.list;

        Delete();
        for (int i = 0; i < QuestList.Count; i++)
        {
            GameObject Quest = Instantiate(PrefabHolder.Instance.Quest,areaQuest.transform) as GameObject;
            Quest.GetComponent<Quest>().SetQuest(QuestList[i]);
        }

        for (int i = 0; i < BtnQuestList.Count; i++)
        {
            //Debug.Log("through");
            int num = i % 4;
            Button Btn = BtnQuestList[i].GetComponent<Button>();
            Navigation Navi = Btn.navigation;
            Navi.mode = Navigation.Mode.Explicit;
            int nextIndex = i + 1;
            int preIndex = i - 1;
            if (nextIndex < BtnQuestList.Count)
            {
                Navi.selectOnRight = BtnQuestList[nextIndex].GetComponent<Button>();
                //Debug.Log("get");
            }

            if (preIndex >= 0)
            {
                Navi.selectOnLeft = BtnQuestList[preIndex].GetComponent<Button>();
            }

            Btn.navigation = Navi;
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
