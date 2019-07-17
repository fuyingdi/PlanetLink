using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starCatch : MonoBehaviour
{
    private GameObject player;
    public float cathSpeed;
    public float upDistance;
    private bool catched=false;
    private void Update()
    {
        if (catched) {
            Vector3 targetPos = player.transform.position + player.transform.up* upDistance;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, cathSpeed * Time.deltaTime);
            if ((transform.position - targetPos).magnitude < 0.1f)
            {
                catched = false;
                player.GetComponent<shootAndCatch>().haveCatch=2;
            }
        }
    }
    public void myCatch(GameObject myPlayer) {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
        transform.parent = myPlayer.transform;
        player = myPlayer;
        catched = true;
    }
}
