using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class stage : MonoBehaviour
{
    public GameObject stopMenu;
    public Button restartBtn,continueBtn,quitBtn;
    void Start()
    {
        Time.timeScale = 1;
        restartBtn.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("test", LoadSceneMode.Single);
        });

        quitBtn.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("title", LoadSceneMode.Single);
        });
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (stopMenu.activeSelf)
            {
                stopMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                stopMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
