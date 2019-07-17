using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMove : MonoBehaviour
{
    public Vector2 dir;
    Rigidbody2D rg;
    public float speed = 0.2f;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(dir.x, dir.y, 0) * speed * 0.01f;
        //rg.velocity = dir * speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }
}
