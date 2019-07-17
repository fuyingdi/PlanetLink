using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Vector2[] slots = new Vector2[6];
    public float speed=0f;
    public Vector3 local_pos;
    private GameObject[] nextGameObject=new GameObject[6];
    Rigidbody2D rg;
    GameObject parent_model;

    public bool isCombined = false;

    public int unicount = 1; //当前相连的同色的数量
    public List<GameObject> uniobject;

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

        //每帧强制更新local坐标
        //if (transform.parent != null)
        //{
        //    transform.localPosition = local_pos;
        //}



    }

    //合并，target=>目标  source=>子簇
    private void OnCollision(GameObject target, GameObject source)
    {
        float[] distance = new float[6];
        float min_dis = 100f;
        int min_index = 0;
        for (int i = 0; i < 6; i++)
        {
            float tmp_dis = (new Vector2(source.transform.position.x, source.transform.position.y) - slots[i]).magnitude;
            if (tmp_dis < min_dis)
            {
                min_dis = tmp_dis;
                min_index = i;
            }
        }
        // 把source放到slot位置上
        source.transform.position = slots[min_index];
        source.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        rg.velocity = new Vector2(0, 0);
        

        //if (target.transform.parent == null)
        //{
        //    GameObject parent = Instantiate(parent_model, target.transform.position, Quaternion.identity);
        //    target.transform.SetParent(parent.transform);
        //    target.transform.SetParent(parent.transform);
        //}
        //else
        //{
        //    source.transform.parent = target.transform.parent;
        //}


    }

    private void Eliminate()
    {
        List<Transform> list=new List<Transform>();
        for (int i=0; i <uniobject.Count; i++)
        {
            if(uniobject[i].tag==gameObject.tag)
            {
                Debug.Log("消除邻接的球");
                Destroy(uniobject[i]);
            }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //获取碰撞点
        Vector2 hit_point;
        hit_point = collision.GetContact(0).point;



        GameObject target = collision.gameObject;

        target.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        rg.velocity = new Vector2(0, 0);

        if (target.tag == "Bubble"|| target.tag=="BubbleA"||target.tag=="BubbleB"||target.tag=="BubbleC")
        {
            rg.constraints = RigidbodyConstraints2D.FreezeAll;
            target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


            Bubble bubble = target.GetComponent<Bubble>();
            #region
            ////两簇相撞时，判断合并到谁，优先按子物体数量判断，其次按速度判断
            ////A B均为复数个
            //if (transform.parent != null && target.transform.parent != null)
            //{
            //    if (transform.parent.childCount > target.transform.childCount)
            //    {
            //        //A的个数大于B的个数
            //        //B合并在A上
            //        OnCollision(gameObject, target);
            //    }
            //    else if (transform.parent.childCount < target.transform.childCount)
            //    {
            //        //B的个数大于A的个数
            //        //A合并在B上
            //        OnCollision(target, gameObject);
            //    }
            //    else
            //    {
            //        //个数相等，比较速度
            //        if (speed < bubble.speed)
            //        {
            //            //A速度小于B速度
            //            //B合并到A上
            //            OnCollision(gameObject, target);
            //        }
            //        else
            //        {
            //            //B速度大于等于A速度
            //            //A合并到B上
            //            OnCollision(target, gameObject);
            //        }
            //    }
            //}
            //else
            //{
            //    //个数相等，比较速度
            //    if (speed < bubble.speed)
            //    {
            //        //A速度小于B速度
            //        //B合并到A上
            //        OnCollision(gameObject, target);
            //    }
            //    else
            //    {
            //        //B速度大于等于A速度
            //        //A合并到B上
            //        OnCollision(target, gameObject);
            //    }
            //}
            #endregion
            if (speed < bubble.speed)
            {
                float[] distance = new float[6];
                float min_dis = 100f;
                int min_index = 0;
                for (int i = 0; i < 6; i++)
                {
                    float tmp_dis = (new Vector2(target.transform.position.x, target.transform.position.y) - slots[i]).magnitude;
                    if (tmp_dis < min_dis)
                    {
                        min_dis = tmp_dis;
                        min_index = i;
                    }
                }
                // 把飞来的物体放到slot位置上
                Debug.Log("target" + target.name);
                Debug.Log("slot index" + min_index);
                Debug.Log("slot pos " + slots[min_index]);
                bubble.local_pos = slots[min_index];
                target.transform.position = slots[min_index];

                target.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                rg.velocity = new Vector2(0, 0);

                rg.constraints = RigidbodyConstraints2D.FreezeAll;
                target.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


                //标记
                nextGameObject[min_index] = target;
                print(nextGameObject[min_index]);
            }

            if (transform.parent == null && target.transform.parent == null)
            {
                Debug.Log(name);
                GameObject parent = Instantiate(parent_model, transform.position, Quaternion.identity);
                transform.SetParent(parent.transform);
                target.transform.SetParent(parent.transform);
            }
            else if (target.transform.parent == null && transform.parent != null)
            {
                target.transform.parent = transform.parent;
            }
            else if (target.transform.parent != null && transform.parent == null)
            {
                ;

            }

            uniobject.Add(target);

            if(gameObject.tag == target.tag)
            {
                unicount++;
                //bubble.unicount++;
            }
            if(unicount==3)
            {
                Eliminate();
                Destroy(gameObject);
            }
            isCombined = true;

        }

        
    }
}

