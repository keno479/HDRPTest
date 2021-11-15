using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using anogamelib;

public class ShowHome : MonoBehaviour
{
    public GameObject WindowHome;
    private GameObject UnitObject;
    //public Scene Home;

    private void OnEnable()
    {
        //SceneManager.MoveGameObjectToScene(WindowHome, Home);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            UIAssistant.Instance.ShowPage("Home");
            UnitObject = other.gameObject;
            UnitObject.GetComponent<UnitController>().SetCanWalk(false);
        }
    }

    public void Exit()
    {
        UIAssistant.Instance.ShowPage("idle");
        if (UnitObject != null) 
        {
            UnitObject.GetComponent<UnitController>().SetCanWalk(true);
            UnitObject = null;
        } 
    }
}
