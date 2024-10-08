using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int score;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        score = scoreManager.GetScore();
        ScoreText.text = string.Format("Score:{0}",score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
