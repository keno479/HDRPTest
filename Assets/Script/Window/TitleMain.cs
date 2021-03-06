using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using anogamelib;
using UnityEngine.SceneManagement;

public class TitleMain : Singleton<TitleMain>
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnClick();
        }
    }

    public void OnClick()
    {
        //Debug.Log("click");
        if (TitleData.Instance.GameInfo.HasKey("PlayerName"))
        {
            SceneManager.LoadScene("Home");
        }
        else
        {
            Debug.Log("enter");
            UIAssistant.Instance.ShowPage("NameInput");
        }
    }
}
