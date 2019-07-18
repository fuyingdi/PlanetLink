using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class title : MonoBehaviour
{
    public Button start,end;
    public AudioSource buttonDown;
    // Start is called before the first frame update 
    void Start()
    {
        start.onClick.AddListener(delegate ()
        {
            buttonDown.Play();
            SceneManager.LoadScene("test", LoadSceneMode.Single);
        });
        end.onClick.AddListener(delegate ()
        {
            buttonDown.Play();
            Application.Quit();
        });
    }
}
