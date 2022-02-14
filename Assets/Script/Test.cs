using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using anogamelib;
using Chronos;

public class Test : MonoBehaviour
{
    public GameObject menubtn;
    public EventBool PoseHandler;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            //Timekeeper.instance.Clock("InGame").paused = true;
            PoseHandler.Invoke(true);
            UIAssistant.Instance.ShowPage("ButtonSelected");
            select();
        }

        if (EventSystem.current.enabled && Input.GetKeyDown(KeyCode.F2)) 
        {
            cancel();
            UIAssistant.Instance.ShowParentPage();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameDirector.Instance.Heal();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UIAssistant.Instance.ShowPage("Status");
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Enter");
        }

        
    }

    public void select()
    {
        EventSystem.current.SetSelectedGameObject(menubtn);
    }

    public void cancel()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
