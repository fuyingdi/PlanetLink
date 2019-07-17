using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] spawn_target = new GameObject[3];
    public float spawn_cd = 1f;
    float tmp_time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tmp_time <= 0)
        {
            tmp_time = spawn_cd;
            int index = Random.Range(0, 3);
            Vector2 pos = new Vector2(Random.Range(-8f, 8f), Random.Range(-5f, 5f));
            Instantiate(spawn_target[index], pos, Quaternion.identity);
        }
        else
            tmp_time -= Time.deltaTime;
    }
}
