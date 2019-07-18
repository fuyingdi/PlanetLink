using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAnimaCon : MonoBehaviour
{
   public AudioSource backGroundMusic;
    
    public AudioSource flameSound;
    public GameObject tailFlame;

    public GameObject explosion;

    public AudioSource planetDes;

    // Start is called before the first frame update
    void Start()
    {
        tailFlame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Time.timeScale - 0 <= 0.1f)
)
        {
            backGroundMusic.Play();
        }
        if (Input.GetKey(KeyCode.W))
        {
            tailFlame.SetActive(true);
            if(!flameSound.isPlaying){
                flameSound.Play();
            }
        }
        else
        {
            tailFlame.SetActive(false);
            flameSound.Stop();
        }

    }
    public void shipExplosion(GameObject father){
        Instantiate(explosion,father.transform.position,Quaternion.identity);
    }

    public void planetDestory(){
        planetDes.Play();
    }
}
