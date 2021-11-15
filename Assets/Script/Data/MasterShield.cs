using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class MasterShieldParam : CsvDataParam
{
    public int Shield_ID;
    public string Shield_Name;
    public int Defense;
    public int Craft_Item_ID1;
    public int Craft_Item_ID2;
    public int Craft_Item_ID3;
    public int Craft_Item1_Value;
    public int Craft_Item2_Value;
    public int Craft_Item3_Value;
    public int Craft_Gold_Cost;
    public string Sprite_Name;
}

public class MasterShield : CsvData<MasterShieldParam>
{

}