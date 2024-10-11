using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Single m_rotateTime;

    [SerializeField] private Single m_walkSpeed;
    [SerializeField] private Single m_runSpeed;
    [SerializeField] private Single m_accel;
    

    private Single m_currentSpeed;
    private Single m_currentHorizSpeed;
    private Single m_currentVertSpeed;

    private Single m_rotationVelocity;

    private Single m_stamina;
    private bool isGrounded;
    public Boolean isRunning;


    private Animator m_animator;
    private Rigidbody m_characterController;
    private PlayerCamera m_playerCamera;
    private PlayerState playerState;

    private void Awake()
    {
        m_playerCamera = GetComponent<PlayerCamera>();
        m_animator = GetComponent<Animator>();
        m_characterController = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
    }
    private void Update()
    {

        Single horiz = Input.GetAxisRaw("Horizontal");
        Single vert = Input.GetAxisRaw("Vertical");
        Jump();

        if(playerState.stamina >= 0)
            isRunning = Input.GetKey(KeyCode.LeftShift);


        Vector3 input = new Vector3(horiz, 0, vert);

        m_animator.SetFloat("speed", m_currentSpeed);

        m_currentHorizSpeed = Mathf.Lerp(
            m_currentHorizSpeed,
            horiz,
            10 * Time.deltaTime);

        m_currentVertSpeed = Mathf.Lerp(
            m_currentVertSpeed,
            vert,
            10 * Time.deltaTime);

        //magnitude : 크기
        //sqrMagnitude : 루트 안씌운 크기
        if (input.sqrMagnitude == 0)
        {
            m_currentSpeed -= m_accel * Time.deltaTime;
            if (m_currentSpeed <= 0)
                m_currentSpeed = 0;

            return;
        }

        Single maxSpeed = isRunning ? m_runSpeed : m_walkSpeed;

        if (m_currentSpeed <= maxSpeed)
        {
            m_currentSpeed += m_accel * Time.deltaTime;
            m_currentSpeed
                = Mathf.Clamp(m_currentSpeed, 0, maxSpeed);
            //현재값 최소 최대
            //현재 값이 최소보다 작으면 최소로 고정
            // 최대보다 크면 최대로 고정
        }
        else //최대 속도보다 크다?
        //달리고 잇다가 달리기에서 떼는데 여전히 앞으로 가고있는 상황
        {
            m_currentSpeed -= m_accel * Time.deltaTime;
            m_currentSpeed
                = Mathf.Clamp(m_currentSpeed, 0, Single.MaxValue);
        }

        Single targetRotation = Mathf.Atan2(
            input.x,
            input.z
            ) * Mathf.Rad2Deg
            + m_playerCamera.GetCameraAngle(); //

        Vector3 targetDirection
            = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;

        m_characterController.velocity
            = targetDirection * m_currentSpeed * Time.deltaTime * 10;
        if (isRunning)
        {
            playerState.stamina -= 0.3f;
            m_characterController.velocity *= 1.5f;
            playerState.BarOn();
        }
        else if(!isRunning && playerState.isSliderOn == true) playerState.Baroff();

        Single dampedRotation = Mathf.SmoothDampAngle(
            transform.localEulerAngles.y,
            targetRotation,
            ref m_rotationVelocity,
            m_rotateTime
            );

        transform.localEulerAngles = new Vector3(
                transform.localEulerAngles.x,
                dampedRotation,
                transform.localEulerAngles.z);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            m_characterController.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            //m_animator.SetBool("jump", !isGrounded);
        }
    }

    bool CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 1.1f)) //hit 뒤에 붙는건 제 컴퓨터 이슈로 값을 다른 컴퓨터에서 조정해야함... 
        {
            if (hit.transform.tag != null)
            {
                isGrounded = true;
                return isGrounded;
            }
        }
        isGrounded = false;
        return isGrounded;
    }
}
