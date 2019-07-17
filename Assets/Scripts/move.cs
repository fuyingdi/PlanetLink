using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D rg;
    public float speed = 0.01f;
    public Vector2 dir;

    public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
     //   dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
            //rg.velocity = dir * speed;
            transform.Translate(dir*speed);
        //Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //rg.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Bubble"|| collision.gameObject.tag == "BubbleA"|| collision.gameObject.tag == "BubbleB"|| collision.gameObject.tag == "BubbleC")
        {
            flag = false;
        }
    }
}
