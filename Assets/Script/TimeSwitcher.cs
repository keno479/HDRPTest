using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitcher : MonoBehaviour
{
    public UnitController unitController;
    public GameObject NotNull;

    private void OnEnable()
    {
        NotNull.SetActive(false);
        unitController.TimeSwitch = true;
        //Debug.Log(unitController.TimeSwitch);
    }

    private void OnDisable()
    {
        NotNull.SetActive(true);
        unitController.TimeSwitch = false;
        //Debug.Log(unitController.TimeSwitch);
    }
}
