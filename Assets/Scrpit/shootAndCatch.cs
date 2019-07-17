using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAndCatch : MonoBehaviour
{
    public int haveCatch = 0;
    public float shootSpeed = 5;
    public GameObject lightBody;
    private GameObject bullet;
    private void OnBecameVisible()

    {

        print("摄像机视野内");

    }
    private void OnBecameInvisible()
    {
        print(transform.position);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (haveCatch == 0)
            {
                RaycastHit2D[] hitRayList;
                print(transform.forward);
                hitRayList = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), transform.up, 100);
                for (int i = 0; i < hitRayList.Length; i++)
                {
                    if (hitRayList[i].collider.tag == "BubbleA"||hitRayList[i].collider.tag=="BubbleB"|| hitRayList[i].collider.tag == "BubbleC")
                    {
                        
                        bullet = hitRayList[i].collider.gameObject;

                        lightBody.SetActive(true);
                        lightBody.GetComponent<light>().setLength((bullet.transform.position - transform.position).magnitude);
                        if (bullet.GetComponent<Bubble>().isCombined == false)
                        {
                            hitRayList[i].collider.GetComponent<starCatch>().myCatch(gameObject);
                            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2();

                            bullet.GetComponent<move>().flag=false;

                            haveCatch = 1;
                            break;
                        }
                    }
                }
            }
            else if (haveCatch == 2)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.up * shootSpeed;
                bullet.transform.parent = null;
                //bullet.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                bullet.GetComponent<Collider2D>().enabled = true;
                haveCatch = 0;
            }
        }

    }
}
