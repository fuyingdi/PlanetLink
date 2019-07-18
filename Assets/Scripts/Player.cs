using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int HP=5;
    //public Text HPText;
    public GameObject HPShow;
    bool canHurt=true;
    public float cantHurtTime = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (HPText != null)
        //    HPText.text = HP.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        GameObject g = collision.gameObject;
        Debug.Log(g.tag);
        if ((g.tag == "BubbleA" || g.tag == "BubbleB" || g.tag == "BubbleC") && canHurt)
        {
            HP--;
            HPShow.GetComponent<HPControl>().decreaseHp();
            if(HP<=0)
            {
                
                Destroy(gameObject);
            }
            canHurt = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Invoke("setCanHurt", cantHurtTime);
        }
    }

    void setCanHurt()
    {
        canHurt = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
