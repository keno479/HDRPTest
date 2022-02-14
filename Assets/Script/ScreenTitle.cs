using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenTitle : MonoBehaviour
{
    public GameObject Select;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(Select);
    }
}
