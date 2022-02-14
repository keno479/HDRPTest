using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEnemyLevel : MonoBehaviour
{
    private Camera TargetCamera;
    private Vector3 TargetPosition;
    private Vector3 Move;

    void Start()
    {

    }

    void Update()
    {
        transform.position = TargetCamera.WorldToScreenPoint(TargetPosition) + Move;
    }

    public void Initialize(int level, Camera cam, Vector3 position)
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = level.ToString();
        TargetCamera = cam;
        TargetPosition = position;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
