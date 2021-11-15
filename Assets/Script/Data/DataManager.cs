using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;
using TMPro;

public class DataManager : Singleton<DataManager>
{
    public TextAsset MasterWeaponSource;
    public TextAsset MasterEnemySource;
    public TextAsset MasterShieldSource;
    public TextAsset MasterItemSource;
    public TextAsset MasterQuestSource;
    public TextAsset MasterStageSource;
    public MasterWeapon masterweapon = new MasterWeapon();
    public MasterShield mastershield = new MasterShield();
    public MasterItem masteritem = new MasterItem();
    public MasterEnemy masterenemy = new MasterEnemy();
    public MasterQuest masterquest = new MasterQuest();
    public MasterStage masterstage = new MasterStage();
    public DataWeapon dataWeapon = new DataWeapon();
    public DataItem dataItem = new DataItem();
    public DataUnit dataunit = new DataUnit();
    public DataShild datashield = new DataShild();
    public DataEnemy dataenemy = new DataEnemy();
    public DataQuest dataquest = new DataQuest();
    public DataStage datastage = new DataStage();
    public DataUnitParam UnitPlayer;
    public KVS GameInfo = new KVS();
    public TextMeshProUGUI PlayerName;

    public override void Initialize()
    {
        base.Initialize();
        GameInfo.SetSaveFilename("GameInfo");
        if (GameInfo.Load() == false)
        {
            GameInfo.SetInt(Define.KeyGold, 0);
            GameInfo.SetInt(Define.KeyStone, 0);
            GameInfo.SetInt(Define.KeyEquipWeaponID, Define.DefaultWeaponID);
            GameInfo.Save();
        }

        masterweapon.Load(MasterWeaponSource);
        dataWeapon.SetSaveFilename("Data_Weapon");
        if (dataWeapon.Load() == false)
        {
            dataWeapon.Add(Define.DefaultWeaponID);
            dataWeapon.Save();
        }
        //dataWeapon.Load("Data_Weapon");

        masteritem.Load(MasterItemSource);
        dataItem.SetSaveFilename("Data_Item");
        if (dataItem.Load() == false)
        {
            dataItem.Save();
        }

        mastershield.Load(MasterShieldSource);
        datashield.SetSaveFilename("Data_Shield");
        if (datashield.Load() == false)
        {
            foreach (MasterShieldParam q in mastershield.list)
            {
                DataShieldParam data = new DataShieldParam
                {
                    Shield_ID = q.Shield_ID,
                    Have = false,
                    Recipe_Have = false
                };
                datashield.list.Add(data);
            }
            datashield.Save();
        }

        dataunit.SetSaveFilename("Data_Unit");
        if (dataunit.Load() == false)
        {
            DataUnitParam player = new DataUnitParam
            {
                HP = 50,
                HP_max = 50,
                EXP = 0,
                EXP_max = 100,
                STR = 5,
                VIT = 5,
                AGI = 5,
                LUK = 5,
                LV = 1,
                Attack = 1,
                Defense = 1,
                Weapon_Attack = 0
            };
            dataunit.list.Add(player);
            dataunit.Save();
        }
        UnitPlayer = dataunit.list[0];

        masterenemy.Load(MasterEnemySource);
        dataenemy.SetSaveFilename("Data_Enemy");
        if (dataenemy.Load() == false)
        {
            dataenemy.Save();
        }

        masterquest.Load(MasterQuestSource);
        dataquest.SetSaveFilename("Data_Quest");
        if (dataquest.Load() == false)
        {
            foreach(MasterQuestParam q in masterquest.list)
            {
                DataQuestParam data = new DataQuestParam
                {
                    Quest_ID = q.Quest_ID,
                    Clear_bool = false
                };
                dataquest.list.Add(data);
            }
            dataquest.Save();
        }

        masterstage.Load(MasterStageSource);
        datastage.SetSaveFilename("Data_Stage");
        if (datastage.Load() == false)
        {
            foreach(MasterStageParam q in masterstage.list)
            {
                DataStageParam data = new DataStageParam
                {
                    Stage_ID = q.Stage_ID,
                    is_Open = false
                };
                datastage.list.Add(data);
                data.is_Open = q.Key_Boss_ID == 0;
            }
        }
        datastage.Save();

        if (GameInfo.HasKey("PlayerName"))
        {
            PlayerName.text = $"{GameInfo.GetValue("PlayerName")}";
        }

        GameDirector.Instance.Init();
    }
}
