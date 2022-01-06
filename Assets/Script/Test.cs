using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using anogamelib;

public class Test : MonoBehaviour
{
    public GameObject menubtn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            select();
        }

        if (EventSystem.current.enabled && Input.GetKeyDown(KeyCode.F2))
        {
            cancel();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameDirector.Instance.Heal();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UIAssistant.Instance.ShowPage("Status");
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
