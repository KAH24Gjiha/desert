using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{

    [SerializeField] private Single m_walkSpeed;
    [SerializeField] private Single m_runSpeed;
    [SerializeField] private Single m_accel;

    private Single m_currentSpeed;

    private bool isFinding;
    Vector3 input;


    private Animator m_animator;
    private Rigidbody m_characterController;

    public Transform Player;
    public PlayerState playerState;

    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        m_animator = GetComponent<Animator>();
        m_characterController = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player").transform;
        playerState = Player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Atk();
    }
    private void Move()
    {
        
        if (!isFinding)
        {
            input = new Vector3(0, 0, 0);
        }
        else
        {
            input = this.transform.position - Player.position;
        }
        Debug.Log(input);

        m_animator.SetFloat("speed", m_currentSpeed);


        if (Vector3.Distance(Player.position, this.transform.position) <= 5)
            isFinding = true;
        //magnitude : ũ��
        //sqrMagnitude : ��Ʈ �Ⱦ��� ũ��
        if (input.sqrMagnitude == 0)
        {
            m_currentSpeed -= m_accel * Time.deltaTime;
            if (m_currentSpeed <= 0)
                m_currentSpeed = 0;

            return;
        }

        Single maxSpeed = isFinding ? m_runSpeed : m_walkSpeed;

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
            ) * Mathf.Rad2Deg;

        Vector3 targetDirection
            = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;

        m_characterController.velocity
            = targetDirection * m_currentSpeed * Time.deltaTime * 10;
        if (isFinding) m_characterController.velocity *= 1.5f;
    }
    private void Atk()
    {
        if (Vector3.Distance(Player.position, this.transform.position) <= 1)
            playerState.Damage();
    }
}
