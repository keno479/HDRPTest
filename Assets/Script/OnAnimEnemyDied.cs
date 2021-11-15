using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnAnimEnemyDied : StateMachineBehaviour
{
    public Action Callback;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Callback != null)
        {
            Callback.Invoke();
        }
    }
}
