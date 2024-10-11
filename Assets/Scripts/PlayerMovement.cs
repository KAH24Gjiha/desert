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

        //magnitude : ũ��
        //sqrMagnitude : ��Ʈ �Ⱦ��� ũ��
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
            //���簪 �ּ� �ִ�
            //���� ���� �ּҺ��� ������ �ּҷ� ����
            // �ִ뺸�� ũ�� �ִ�� ����
        }
        else //�ִ� �ӵ����� ũ��?
        //�޸��� �մٰ� �޸��⿡�� ���µ� ������ ������ �����ִ� ��Ȳ
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
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 1.1f)) //hit �ڿ� �ٴ°� �� ��ǻ�� �̽��� ���� �ٸ� ��ǻ�Ϳ��� �����ؾ���... 
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
