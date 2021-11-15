using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public TextMeshProUGUI TextContent;
    public TextMeshProUGUI TextReward;
    public TextMeshProUGUI TextAchievementRate;
    public GameObject BadgeClear;
    private int Achievement_Rate;
    private List<DataEnemyParam> EnemyList = new List<DataEnemyParam>();
    public int Quest_ID;

    public void SetQuest(MasterQuestParam _param)
    {
        EnemyList = DataManager.Instance.dataenemy.list;
        DataEnemyParam param =
            DataManager.Instance.dataenemy.list.Find(p => p.Enemy_ID == _param.Target_ID);
        DataQuestParam dataquest =
            DataManager.Instance.dataquest.list.Find(p => p.Quest_ID == _param.Quest_ID);
        Quest_ID = _param.Quest_ID;

        TextContent.text = $"{_param.Quest_Content}";

        if (_param.Reward_Type == 1)
        {
            MasterShieldParam shieldparam = 
                DataManager.Instance.mastershield.list.Find(p => p.Shield_ID == _param.Reward_ID);
            TextReward.text = $"報酬:{shieldparam.Shield_Name}のレシピ";
        }
        else
        {
            TextReward.text = "error";
        }

        if (_param.Target_ID == 100)
        {
            if (_param.Target_Type == "Monster")
            {
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    Achievement_Rate += EnemyList[i].Kill_Count;
                }
            }
            else
            {
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    MasterEnemyParam enemy = 
                        DataManager.Instance.masterenemy.list.Find(p => p.Enemy_ID == EnemyList[i].Enemy_ID);
                    if (_param.Target_Type == enemy.Enemy_Type)
                    {
                        Achievement_Rate += EnemyList[i].Kill_Count;
                    }
                }
            }
        }
        else if (param != null) 
        {           
            Achievement_Rate = param.Kill_Count;
        }
        TextAchievementRate.text = $"{Achievement_Rate}/{_param.Goal}";

        if (Achievement_Rate >= _param.Goal)
        {
            BadgeClear.SetActive(true);
            dataquest.Clear_bool = true;
            DataManager.Instance.dataquest.Save();
        }

        
    }

    public void GetReward()
    {
        MasterQuestParam master = 
            DataManager.Instance.masterquest.list.Find(p => p.Quest_ID == Quest_ID);
        DataQuestParam data =
            DataManager.Instance.dataquest.list.Find(p => p.Quest_ID == Quest_ID);
        

        if (data.Clear_bool)
        {
            if (master.Reward_Type == 1)
            {
                DataShieldParam shield =
                    DataManager.Instance.datashield.list.Find(p => p.Shield_ID == master.Reward_ID);
                shield.Recipe_Have = true;
                DataManager.Instance.datashield.Save();
            }
        }
    }
}
