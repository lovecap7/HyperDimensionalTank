using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // 制限時間
    [SerializeField] int timeLimit;

    // タイマー用テキスト
    [SerializeField] TextMeshProUGUI timerText;


    //スタートするまで動けない
    private StartCount startCount;
    [SerializeField] private GameObject startCountObj;
    // 経過時間
    float time = 0.0f;
    private void Start()
    {
        //フレームレートを60fpsにする
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        // time変数にをint型にし制限時間から引いた数をint型のlimit型のに代入
        int remaining = timeLimit - (int)time;
        // timerTextを更新していく
        timerText.text = $"のこり : {remaining.ToString("D3")}";
        if (startCountObj != null)
        {
            return;
        }
        // フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        
       

        if(remaining <= 0 )
        {
            SceneManager.LoadScene("SingleResultScene");
        }
        
    }
}
