using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationDetector : MonoBehaviour
{
    public UnityEvent AnimationEndHandler = new UnityEvent();
    public UnityEvent AttackHitHandler = new UnityEvent();
    public void OnAnimationEnd()
    {
        AnimationEndHandler.Invoke();
    }

    public void OnAttackHit()
    {
        AttackHitHandler.Invoke();
    }
}
