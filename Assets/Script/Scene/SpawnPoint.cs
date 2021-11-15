using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            System.Type t = typeof(UnitController);
            if ((FindObjectOfType(t) as UnitController) != null)
            {
                Transform Player = (FindObjectOfType(t) as UnitController).transform;
                Player.position = transform.position;
                break;
            }
            yield return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
