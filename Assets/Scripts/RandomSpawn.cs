using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] spawn_target = new GameObject[3];
    public float spawn_cd = 1f;
    float tmp_time;
    public float speedup = 0.001f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tmp_time <= 0)
        {
            tmp_time = spawn_cd/(1+speedup*Time.time);
            int index = Random.Range(0, 3);

            Vector2 pos1 = new Vector2(10f, Random.Range(-4f, 4f));
            Vector2 pos2 = new Vector2(-10f, Random.Range(-4f, 4f));
            Vector2 pos3 = new Vector2(Random.Range(-8f,8f), 6f);
            Vector2 pos4 = new Vector2(Random.Range(-8f, 8f), -6f);
            GameObject bu;

            int rand = Random.Range(0, 4);
            switch (rand)
            {
                case 0:
                    bu = Instantiate(spawn_target[index], pos1, Quaternion.identity);
                    bu.GetComponent<move>().dir = new Vector2(Random.Range(-0.8f, -0.6f) * (1 + speedup * Time.time), 0);
                    break;
                case 1:
                    bu = Instantiate(spawn_target[index], pos2, Quaternion.identity);
                    bu.GetComponent<move>().dir = new Vector2(Random.Range(0.6f, 0.8f) * (1 + speedup * Time.time), 0);
                    break;
                case 2:
                    bu = Instantiate(spawn_target[index], pos3, Quaternion.identity);
                    bu.GetComponent<move>().dir = new Vector2(0,Random.Range(-0.8f, 0.6f) * (1 + speedup * Time.time));
                    break;
                case 3:
                    bu = Instantiate(spawn_target[index], pos4, Quaternion.identity);
                    bu.GetComponent<move>().dir = new Vector2(0, Random.Range(0.6f, 0.8f)*(1+speedup*Time.time));
                    break;

            }


        }
        else
            tmp_time -= Time.deltaTime;
    }
}
