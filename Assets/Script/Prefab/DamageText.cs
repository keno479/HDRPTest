using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamageText : MonoBehaviour
{
    //private float speed = 2400.0f;
    private Camera TargetCamera;
    private Vector3 TargetPosition;
    private Vector3 Move;

    void Start()
    {
        
        Destroy(gameObject, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        /*gameObject.transform.Translate(0, speed, 0);
        ;*/
        //Move += Vector3.up * speed * Time.deltaTime;
        transform.position = TargetCamera.WorldToScreenPoint(TargetPosition) + Move;
        //speed *= 0.98f * ((float)Application.targetFrameRate / 60f);
    }

    public void Initialize(int damage,Camera cam,Vector3 position)
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = damage.ToString();
        TargetCamera = cam;
        TargetPosition = position;
        DOTween.To(value =>
        {
            Move = new Vector3(0, value);
        }, 0, 100, 1.2f).SetEase(Ease.InBounce);
    }
}
