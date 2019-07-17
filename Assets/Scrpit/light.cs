using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public float lightTime;
    public GameObject lightHead;
    public void setLength(float value) {
        float length = Mathf.Max(0, value-1.5f);
        lightTime = 0.3f;
        GetComponent<SpriteRenderer>().size =new Vector2(GetComponent<SpriteRenderer>().size.x, length) ;
        lightHead.transform.position = transform.position+ length * transform.up;
    }
    void Update()
    {
        if (lightTime > 0)
        {
            lightTime -= Time.deltaTime;
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
