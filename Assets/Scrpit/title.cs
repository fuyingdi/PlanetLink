using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class title : MonoBehaviour
{
    public Button start,end;
    // Start is called before the first frame update 
    void Start()
    {
        start.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("stage", LoadSceneMode.Single);
        });
        end.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }
}
