using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TitleCamera : MonoBehaviour
{
    public CinemachineFreeLook freeLook;
    
    private void Update()
    {
        freeLook.m_XAxis.m_InputAxisValue = 0.2f;
    }
}
