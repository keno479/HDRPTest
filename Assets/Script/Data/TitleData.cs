using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;

public class TitleData : Singleton<TitleData>
{
    public KVS GameInfo = new KVS();
    public KVS Config = new KVS();
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

        Config.SetSaveFilename("Config");
        if (Config.Load() == false)
        {
            Config.SetInt(Define.KeyFPS, Define.DefaultFPS);
            Config.SetInt(Define.KeyBGMOn, 0);
            Config.SetInt(Define.KeyCameraAuto, 0);
            Config.Save();
        }
        SetFPS(Config.GetInt(Define.KeyFPS));
    }

    public void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
        if (Config.GetInt(Define.KeyFPS) != fps)
        {
            Config.SetInt(Define.KeyFPS, fps);
            Config.Save();
        }
    }
    
    public void BGM_on_off(bool bgm_bool)
    {
        if (bgm_bool)
        {
            Config.SetInt(Define.KeyBGMOn, 0);
        }
        else
        {
            Config.SetInt(Define.KeyBGMOn, 1);
        }
        Config.Save();
    }
}
