using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    public float jump = 5f;
    private Rigidbody rigid;

    private bool isGrounded;

    public float sesitivity = 500f; //���콺 �ΰ���2
    public float rotationY;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        Move();
        Jump();
        //���� �Լ� �ֱ� (+���� ������Ʈ �ʿ� �ȳ����ǰŸ� / �ȳ־ �Ǵ� ����̸� ���� �Լ��� ���� �̵��ϰ� ������Ʈ�Լ� ���� ��Ź�ؿ� ����ȭ ����������)
    }
    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 moveVec = transform.forward * inputZ + transform.right * inputX;
        transform.position += moveVec.normalized * speed * Time.deltaTime;

        Camera.main.transform.position = this.transform.position;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            rigid.AddForce(Vector3.up * jump, ForceMode.Impulse);
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


    //���⿡ ���� �Լ� ����ų� �Ͻ� �� �� ���ƿ�
}
