using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rg2d;
    [SerializeField] private float maxSpeed;

    Vector2 moveDirection;
    [SerializeField] private int turnSpeed;
    [SerializeField] private int moveSpeed;

    [SerializeField] private float up;
    [SerializeField] private float down;
    [SerializeField] private float left;
    [SerializeField] private float right;


    // Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = this.GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
        this.transform.position=-this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        moveTowards();
        playerTurn();
        //crossBorder();
    }

    public void moveTowards()   //前进
    {
        // moveDirection.x = Mathf.Sin(this.transform.eulerAngles.z*Mathf.Deg2Rad);
        // moveDirection.y = Mathf.Cos(this.transform.eulerAngles.z*Mathf.Deg2Rad);
        // //Debug.Log(this.transform.eulerAngles.z*Mathf.Deg2Rad);
        // Debug.Log(moveDirection);
        if (Input.GetKey(KeyCode.W))
        {
            rg2d.AddForce(transform.up * Time.deltaTime * moveSpeed, ForceMode2D.Impulse);
            // Debug.Log(rg2d.velocity);
            //Debug.Log(rg2d.velocity.magnitude);
        }
        else
        {
            Vector2.Lerp(rg2d.velocity, Vector2.zero, 5);
        }
        //Debug.Log(rg2d.velocity.magnitude);
    }

    public void playerTurn()    //转向
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, 0, 1) * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, 0, -1) * turnSpeed);
        }
    }

    public void crossBorder()
    {
        Vector3 temp;
        bool isRight = false;
        bool isLeft = false;
        bool isUp = false;
        bool isDown = false;
        if (this.transform.position.x > right && isLeft == false && isRight == true)
        {  //01

            temp = transform.position;
            temp.x = -temp.x;
            this.transform.position = temp;
        }
        if (this.transform.position.x < left && !isRight)
        {
            isLeft = true;
            isRight = false;
            temp = transform.position;
            temp.x = -temp.x;
            this.transform.position = temp;
        }
        // if(this.transform.position.y>up&&!isDown){
        //     isUp=true;
        //     isDown=false;
        //     temp=transform.position;
        //     temp.y=-temp.y;
        //     this.transform.position=temp;
        // }
        // if(this.transform.position.y<down&&!isUp){
        //     isDown=true;
        //     isUp=false;
        //     temp=transform.position;
        //     temp.y=-temp.y;
        //     this.transform.position=temp;
        // }
    }
}
