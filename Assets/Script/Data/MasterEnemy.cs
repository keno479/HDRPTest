using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class MasterEnemyParam : CsvDataParam
{
    public int Enemy_ID;
    public string Enemy_Name;
    public string Enemy_Type;
    public int Attack;
    public int HP;
    public int Base_EXP;
    public int Base_Gold;
    public int Drop_Item_ID1;
    public int Drop_Item_ID2;
    public int Drop_Item_ID3;
    public int LV_max;
    public int LV_min;
    public bool Boss;

    public MasterEnemyParam Build(int level)
    {
        if (level <= 0)
        {
            Debug.LogError($"error:level={level}");
            level = 1;
        }
        MasterEnemyParam ret = new MasterEnemyParam();
        ret.Enemy_ID = Enemy_ID;
        ret.Enemy_Name = Enemy_Name;
        ret.Attack = GetStatus(Attack,level);
        ret.HP = GetStatus(HP, level);
        ret.Base_EXP = GetStatus(Base_EXP, level);
        ret.Base_Gold = GetStatus(Base_Gold, level);
        ret.Drop_Item_ID1 = Drop_Item_ID1;
        ret.Drop_Item_ID2 = Drop_Item_ID2;
        ret.Drop_Item_ID3 = Drop_Item_ID3;
        ret.LV_max = LV_max;
        ret.LV_min = LV_min;
        ret.Boss = Boss;
        return ret;
    }

    private int GetStatus(int status,int level)
    {
        int ret= status+ (int)((status * 0.1) * (level - 1));
        return ret;
    }
}

public class MasterEnemy : CsvData<MasterEnemyParam>
{
    
}
