using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null; // Textオブジェクト

    private int totalScore = 0;

    TextMeshProUGUI scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        //// オブジェクトからTextコンポーネントを取得
        //TextMeshProUGUI scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        //// テキストの表示を入れ替える
        //scoreText.text = "Score00000" + score;
        // オブジェクトからTextコンポーネントを取得
         scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // スコアを増加させるメソッド
    // 外部からアクセスするからpublicで定義させる
    public void AddScore(int amount)
    {
        totalScore += amount;
        scoreText.text = "Score" + totalScore;
    }
    public int GetScore()
    {
        return totalScore;
    }
}
