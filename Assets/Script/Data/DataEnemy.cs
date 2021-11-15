using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class DataEnemyParam : CsvDataParam
{
    public int Enemy_ID;
    public int Kill_Count;
}

public class DataEnemy : CsvData<DataEnemyParam>
{
    public void AddKillCount(int _enemy_id)
    {
        DataEnemyParam param = list.Find(p => p.Enemy_ID == _enemy_id);
        if (param != null)
        {
            param.Kill_Count += 1;
        }
        else
        {
            param = new DataEnemyParam()
            {
                Enemy_ID = _enemy_id,
                Kill_Count = 1
            };
            list.Add(param);
        }
        DataManager.Instance.dataenemy.Save();
    }
}