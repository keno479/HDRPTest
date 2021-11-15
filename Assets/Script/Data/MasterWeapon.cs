using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class MasterWeaponParam : CsvDataParam
{
    public int Weapon_ID;
    public string Weapon_Name;
    public int Attack;
    public int Gacha_Prob;
    public string Sprite_Name;
    public int Craft_Item_ID;
}

public class MasterWeapon : CsvData<MasterWeaponParam>
{
    
}
