using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score score = new Score();
    public int score_num = 0;
    public TextMeshProUGUI score_text;

    void Start()
    {
        Score.score.score_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = Score.score.score_num.ToString();
    }
}
