using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sesitivity = 500f; //마우스 민감도

    public float rotationX;
    public float rotationY;

    public Transform Player;

    public bool isPlay = true;

    void Update()
    {
        rotate();
    }
    void rotate()
    {
        if (Input.GetMouseButton(0) && isPlay == true)
        {
            float mouseMoveX = Input.GetAxis("Mouse X");
            float mouseMoveY = Input.GetAxis("Mouse Y");

            rotationY += mouseMoveX * sesitivity * Time.deltaTime;
            rotationX += mouseMoveY * sesitivity * Time.deltaTime;

            if (rotationX > 35f)
            {
                rotationX = 35f;

            }

            if (rotationX < -30f)
            {
                rotationX = -30f;

            }

            transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
            Player.transform.rotation = Quaternion.Euler(0, rotationY, 0);
        }
    }
}
