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
    public bool CanHome;
    public float Distance;

    private void OnEnable()
    {
        CanHome = true;
        //SceneManager.MoveGameObjectToScene(WindowHome, Home);
    }
    private void Update()
    {
        if (UnitObject != null)
        {
            Distance = (UnitObject.transform.position - transform.position).magnitude;
            if (Distance > 1.5f)
            {
                CanHome = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CanHome) 
        {
            CanHome = false;
            UIAssistant.Instance.ShowPage("Home");
            UnitObject = other.gameObject;
            //UnitObject.GetComponent<UnitController>().SetCanWalk(false);
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
