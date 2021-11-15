using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class MasterItemParam : CsvDataParam
{
    public int Item_ID;
    public string Item_Name;
    public int Gacha_Prob;
    public string Sprite_Name;
}

public class MasterItem: CsvData<MasterItemParam>
{

}