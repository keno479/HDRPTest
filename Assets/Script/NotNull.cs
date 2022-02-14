using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NotNull : MonoBehaviour
{
    private GameObject PreviousSelection;

    private void OnEnable()
    {
        
    }
    /*private IEnumerator RestrictSelection
    {
        get
        {
            while (true)
            {
                yield return new WaitUntil(() => EventSystem.current != null);
                if (PreviousSelection != EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject != null)
                {
                    PreviousSelection = EventSystem.current.currentSelectedGameObject;
                }

                EventSystem.current.SetSelectedGameObject(PreviousSelection);
            }
        }
    }*/
}
