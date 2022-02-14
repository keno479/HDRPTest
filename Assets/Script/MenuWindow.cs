using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuWindow : MonoBehaviour, IDeselectHandler
{
    private GameObject selectedobject;
    public void OnDeselect(BaseEventData eventData)
    {
        //selectedobject = eventData.selectedObject;
        Debug.Log(selectedobject);
        EventSystem.current.SetSelectedGameObject(selectedobject);
    }

    void Update()
    {
        if (selectedobject != EventSystem.current.currentSelectedGameObject &&
            EventSystem.current.currentSelectedGameObject != null) 
        {
            selectedobject = EventSystem.current.currentSelectedGameObject;
        }

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(selectedobject);
        }
    }
}