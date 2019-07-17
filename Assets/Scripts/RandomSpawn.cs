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

            Vector2 pos1 = new Vector2(10f, Random.Range(-5f, 5f));
            GameObject bu = Instantiate(spawn_target[index], pos1, Quaternion.identity);
            bu.GetComponent<move>().dir = new Vector2(Random.Range(-0.8f, -0.6f), 0);

            Vector2 pos2 = new Vector2(-10f, Random.Range(-5f, 5f));
            bu = Instantiate(spawn_target[index], pos2, Quaternion.identity);
            bu.GetComponent<move>().dir = new Vector2(Random.Range(0.6f, 0.8f), 0);




        }
        else
            tmp_time -= Time.deltaTime;
    }
}
