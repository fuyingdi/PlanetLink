using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] HP;
    static int count=4;

    public void decreaseHp(){
        HP[count].SetActive(false);
        count--;
    }
}
