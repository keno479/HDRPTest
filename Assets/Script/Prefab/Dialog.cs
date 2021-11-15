using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using anogamelib;

public class Dialog : Singleton<Dialog>
{
    public float Lifespan;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lifespan += Time.deltaTime;
        if (Lifespan > 1.0f)
        {
            Destroy(gameObject);
        }
    }
   
}
