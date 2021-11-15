using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{
    private bool CameraManual;
    private bool BGM_on_off_bool;
    public TextMeshProUGUI TextCameraMode;
    public TextMeshProUGUI TextBGM_on_off;
    public TextMeshProUGUI TextCurrentFPS;

    private void OnEnable()
    {
        //Application.targetFrameRate = 60;
        CameraManual = true;
        BGM_on_off_bool = TitleData.Instance.Config.GetInt(Define.KeyBGMOn) == 0;
        SetTextFPS();
        SetCameraMode();
        SetTextBGM_on_off(BGM_on_off_bool);
    }

    public void SetTextFPS(int fps = -1)
    {
        if (fps == -1)
        {
            fps = Application.targetFrameRate;
        }
        TextCurrentFPS.text = $"今の設定:{fps}FPS";
    }

    public void SetFPSValue(int fps)
    {
        TitleData.Instance.SetFPS(fps);
        SetTextFPS(fps);
    }
    public void ChangeCameraMode()
    {
        CameraManual = !CameraManual;
        SetCameraMode();
    }

    public void SetCameraMode()
    {
        if (CameraManual)
        {
            TextCameraMode.text = $"マニュアル";
        }
        else
        {
            TextCameraMode.text = $"オート";
        }
    }

    public void BGM_on_off()
    {
        BGM_on_off_bool = !BGM_on_off_bool;
        SetTextBGM_on_off(BGM_on_off_bool);
        TitleData.Instance.BGM_on_off(BGM_on_off_bool);
        AudioManager.Instance.SetBGM();
    }

    public void SetTextBGM_on_off(bool _on)
    {
        if (_on) 
        {
            TextBGM_on_off.text = $"BGMオン";
        }
        else
        {
            TextBGM_on_off.text = $"BGMオフ";
        }
    }
}
