﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAndCatch : MonoBehaviour
{
    public int haveCatch = 0;
    public float shootSpeed = 5;
    public float lightWidth = 0.08f;
    public float alpha = 0.5f;
    public float maxLength = 8.0f;
    public GameObject lightBody;
    private GameObject bullet;
    private void OnBecameVisible()

    {
        ;
        //print("摄像机视野内");

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
                RaycastHit2D[] hitRayListA, hitRayListB, hitRayListC;
                //print(transform.forward);
                Vector2 widPos = lightWidth / 2 * transform.right;
                hitRayListA = Physics2D.RaycastAll(new Vector2(transform.position.x+ widPos.x, transform.position.y), transform.up, maxLength+5);
                hitRayListB = Physics2D.RaycastAll(new Vector2(transform.position.x-widPos.x, transform.position.y), transform.up, maxLength+5);
                hitRayListC = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), transform.up, maxLength+5);
                bullet = null;
                GameObject bulletB, bulletC;
                for (int i = 0; i < hitRayListA.Length; i++)
                {
                    if (hitRayListA[i].collider.tag == "BubbleA"|| hitRayListA[i].collider.tag=="BubbleB"|| hitRayListA[i].collider.tag == "BubbleC")
                    {
                        bullet = hitRayListA[i].collider.gameObject;
                        break;
                    }
                }
                for (int i = 0; i < hitRayListB.Length; i++)
                {
                    if (hitRayListB[i].collider.tag == "BubbleA" || hitRayListB[i].collider.tag == "BubbleB" || hitRayListB[i].collider.tag == "BubbleC")
                    {
                        bulletB = hitRayListB[i].collider.gameObject;
                        if (bullet == null|| (bullet.transform.position-transform.position).magnitude> (bulletB.transform.position - transform.position).magnitude) {
                            bullet = bulletB;
                        }
                        break;
                    }                
                }
                for (int i = 0; i < hitRayListC.Length; i++)
                {
                    if (hitRayListC[i].collider.tag == "BubbleA" || hitRayListC[i].collider.tag == "BubbleB" || hitRayListC[i].collider.tag == "BubbleC")
                    {
                        bulletC = hitRayListC[i].collider.gameObject;
                        if (bullet == null || (bullet.transform.position - transform.position).magnitude > (bulletC.transform.position - transform.position).magnitude)
                        {
                            bullet = bulletC;
                        }
                        break;
                    }
                }
                if (bullet != null) {
                    //bullet.GetComponent<starCatch>().myCatch(gameObject);
                    //bullet.GetComponent<Rigidbody2D>().velocity = new Vector2();
                    lightBody.SetActive(true);
                    lightBody.GetComponent<light>().setLength(maxLength);
                    int count = 0;

                    for (int i = 0; i < 6; i++)
                    {
                        RaycastHit2D[] hitRayList;
                        Vector2 toWard = new Vector2(Mathf.Cos(i * Mathf.PI / 3), Mathf.Sin(i * Mathf.PI / 3));
                        Vector2 originPos = new Vector2(bullet.transform.position.x, bullet.transform.position.y) + bullet.GetComponent<Collider2D>().bounds.size.x * toWard;
                        hitRayList = Physics2D.RaycastAll(originPos, toWard, 0.1f);
                        for (int j = 0; j < hitRayList.Length; j++)
                        {
                            if (hitRayList[j].collider.tag == "BubbleA" || hitRayList[j].collider.tag == "BubbleB" || hitRayList[j].collider.tag == "BubbleC")
                            {
                                count++;
                            }
                        }
                    }
                    if (count == 0)
                    {
                        bullet.GetComponent<starCatch>().myCatch(gameObject);
                        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2();
                        bullet.GetComponent<move>().flag = false;
                        haveCatch = 1;
                    }
                }
                else{
                    lightBody.SetActive(true);
                    lightBody.GetComponent<light>().setLength(maxLength, alpha);
                }
            }
            else if (haveCatch == 2)
            {
                bullet.GetComponent<Rigidbody2D>().velocity = transform.up * shootSpeed;
                bullet.GetComponent<starCatch>().catched = false;
                bullet.transform.parent = null;
                bullet.GetComponent<Collider2D>().enabled = true;
                haveCatch = 0;
            }
        }

    }
}
