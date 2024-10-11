using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Single m_cameraTopClamp;
    [SerializeField] private Single m_cameraBottomClamp;
    [SerializeField] private GameObject m_cameraTarget;
    
    private Single m_cameraTargetYaw;
    private Single m_cameraTargetPitch;


    private void Awake()
    {
        m_cameraTargetYaw
            = m_cameraTarget.transform.eulerAngles.y;
        m_cameraTargetPitch
            = m_cameraTarget.transform.eulerAngles.x;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        Single mouseX = Input.GetAxisRaw("Mouse X");
        Single mouseY = -Input.GetAxisRaw("Mouse Y");

        m_cameraTargetPitch += mouseY * 10;
        m_cameraTargetYaw += mouseX * 10;

        m_cameraTargetPitch = Mathf.Clamp(
            m_cameraTargetPitch,
            m_cameraBottomClamp,
            m_cameraTopClamp
            );

        m_cameraTarget.transform.rotation
            = Quaternion.Euler(
                m_cameraTargetPitch,
                m_cameraTargetYaw,
                0);
    }

    public Single GetCameraAngle() 
    {
        return m_cameraTarget.transform.eulerAngles.y;
    }
}
