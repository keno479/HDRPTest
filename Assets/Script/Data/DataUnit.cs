using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class DataUnitParam : CsvDataParam
{
    public int HP;
    public int HP_max;
    public int EXP;
    public int EXP_max;
    public int STR;
    public int VIT;
    public int AGI;
    public int LUK;
    public int LV;
    public int Attack;
    public int Defense;
    public int Weapon_Attack;
    public int StatusPoint;
    
    public int GetTotalAttack()
    {
        int EquipWeapon_ID;
        MasterWeaponParam masterweapon;
        DataWeaponParam dataweapon;
        EquipWeapon_ID = DataManager.Instance.GameInfo.GetInt(Define.KeyEquipWeaponID);
        masterweapon = DataManager.Instance.masterweapon.list.Find(p => p.Weapon_ID == EquipWeapon_ID);
        dataweapon = DataManager.Instance.dataWeapon.list.Find(p => p.Weapon_ID == EquipWeapon_ID);
        Weapon_Attack = masterweapon.Attack + (dataweapon.Weapon_LV - 1) + (dataweapon.Num - 1);
        return Attack + Weapon_Attack + STR;
    }

    public int GetTotalDefense()
    {
        int EquipShield_ID;
        MasterShieldParam mastershield;
        EquipShield_ID = DataManager.Instance.GameInfo.GetInt(Define.KeyEquipShieldID);
        mastershield = DataManager.Instance.mastershield.list.Find
            (p => p.Shield_ID == EquipShield_ID);
        return Defense + mastershield.Defense + VIT;
    }
}
public class DataUnit : CsvData<DataUnitParam>
{
    
}
