using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName = "ScriptableObject/PlayerData")]
public class PlayerData : ScriptableObject
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
}
