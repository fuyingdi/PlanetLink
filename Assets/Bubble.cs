using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector2[] slots = new Vector2[6];
    GameObject parent_model;
    public float speed=0f;
    Rigidbody2D rg;

    void Start()
    {
        parent_model = GameObject.Find("parent");
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.parent != null)
        //    transform.localPosition = new Vector3(0, 0, 0);
        for(int i =0; i<6; i++)
        {
            slots[i] = transform.GetChild(i).position;
           // Debug.Log(slots[i]);
        }
        speed = rg.velocity.magnitude;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //获取碰撞点
        Vector2 hit_point;
        hit_point = collision.GetContact(0).point;


        GameObject target = collision.gameObject;
        if(target.tag == "Bubble")
        {
            Bubble bubble = target.GetComponent<Bubble>();
            if(speed<bubble.speed)
            {
                float[] distance = new float[6];
                float min_dis = 100f;
                int min_index = 0;
                for (int i =0; i<6; i++)
                {
                    float tmp_dis = (new Vector2(target.transform.position.x, target.transform.position.y) - slots[i]).magnitude;
                    if(tmp_dis<min_dis)
                    {
                        min_dis = tmp_dis;
                        min_index = i;
                    }
                }
                // 把飞来的物体放到slot位置上
                target.transform.position=slots[min_index];
                target.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                rg.velocity = new Vector2(0, 0);

                //rg.constraints = RigidbodyConstraints2D.FreezeAll;
                //target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


                //Debug.Log(target.name);
                //Debug.Log(slots[min_index]);
            }

            Debug.Log(gameObject.transform.parent);
            
            if(transform.parent == null)
            {
                GameObject parent = Instantiate(parent_model, transform.position, Quaternion.identity);
                transform.SetParent(parent.transform);
                target.transform.SetParent(parent.transform);
            }
            else
            {
                target.transform.parent = transform.parent;
            }


        }


    }
}
