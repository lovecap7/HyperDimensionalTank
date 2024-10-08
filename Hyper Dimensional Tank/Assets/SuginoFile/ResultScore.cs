using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score",0);
        ScoreText.text = string.Format("Score:{0}",score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
