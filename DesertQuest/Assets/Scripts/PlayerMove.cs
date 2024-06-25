using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5f;
    public float jump = 5f;
    private Rigidbody rigid;

    private bool isGrounded;
    public bool isRun;

    public float sesitivity = 500f; //마우스 민감도2
    public float rotationY;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        Move();
        Jump();
        //공격 함수 넣기 (+만약 업데이트 쪽에 안넣으실거면 / 안넣어도 되는 방법이면 무브 함수도 같이 이동하고 업데이트함수 삭제 부탁해용 최적화 문제때문에)
    }
    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 moveVec = transform.forward * inputZ + transform.right * inputX;
        transform.position += moveVec.normalized * speed * Time.deltaTime;

        Camera.main.transform.position = this.transform.position;

        if (Input.GetKeyDown(KeyCode.LeftShift) && isRun == false) { speed = 10; isRun = true; this.gameObject.GetComponent<PlayerState>().Run(true); }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { speed = 5; isRun = false; this.gameObject.GetComponent<PlayerState>().Run(false); }
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


    //여기에 공격 함수 만들거나 하심 될 것 같아요
}
