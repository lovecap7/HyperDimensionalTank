using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.SceneTemplate;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{
    private GameObject playerObj1P;
    private GameObject playerObj2P;
    private PlayerScript playerScript1P;
    private PlayerScript playerScript2P;

    //HpUI
    [SerializeField] private Slider hpBar1P;
    [SerializeField] private Slider hpBar2P;
    //beamUI
    [SerializeField] private Slider beamBar1P;
    [SerializeField] private Slider beamBar2P;
   
    //ビームがたまっているかどうかをテキストで表示
    [SerializeField] private GameObject beamTextObj1P;
    [SerializeField] private GameObject beamTextObj2P;
    private TextMeshProUGUI beamText1P;
    private TextMeshProUGUI beamText2P;
    [SerializeField] private GameObject beamMaxEff1P;
    [SerializeField] private GameObject beamMaxEff2P;

    //残機
    [SerializeField] private GameObject[] stockUi1P;
    [SerializeField] private GameObject[] stockUi2P;

    //burrierUI
    [SerializeField] private Slider burrierBar1P;
    [SerializeField] private Slider burrierBar2P;
  

    //Xボタンの表示
    [SerializeField] private GameObject xBottun1P;
    [SerializeField] private GameObject xBottun2P;

   
   //リスぽ
   private int respawnTime1P = 180;
    private int respawnTime2P = 180;
    private GameObject respownPanel1P;
    private GameObject respownPanel2P;
    private GameObject respownTimerObj1P;
    private GameObject respownTimerObj2P;
    private TextMeshProUGUI respownTimerText1P;
    private TextMeshProUGUI respownTimerText2P;

   


   //リス地
   [SerializeField] private GameObject respornPoint1;
    [SerializeField] private GameObject respornPoint2;

    //勝ったプレイヤーの番号を保存　1Pは1 2Pは2
    private int winPlayerIndex = 0;
    [SerializeField] private GameObject gamesetPanel;
    //ゲーム終了フラグ
    private bool isFinish = false;
    [SerializeField] private GameObject endSe;
    //数秒たったらシーン移動
    private int sceneMoveFrame = 90;

    [SerializeField]private GameObject normalBgm;
    [SerializeField]private GameObject climaxBgm;

    //バフ
    [SerializeField] private GameObject buffSp1P;
    [SerializeField] private GameObject buffFs1P;
    [SerializeField] private GameObject buffG1P;

    [SerializeField] private GameObject buffSp2P;
    [SerializeField] private GameObject buffFs2P;
    [SerializeField] private GameObject buffG2P;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        playerObj1P = GameObject.Find("Player1");
        playerObj2P = GameObject.Find("Player2");
        playerScript1P = playerObj1P.GetComponent<PlayerScript>();
        playerScript2P = playerObj2P.GetComponent<PlayerScript>();

        //HPバーをMAXに
        hpBar1P.value = 1;
        hpBar2P.value = 1;
        //ビームのゲージを0に
        beamBar1P.value = 0;
        beamBar2P.value = 0;
        beamText1P = beamTextObj1P.GetComponent<TextMeshProUGUI>();
        beamText2P = beamTextObj2P.GetComponent<TextMeshProUGUI>();
        beamMaxEff1P.SetActive(false);
        beamMaxEff2P.SetActive(false);
        //バリアをMAXに
        burrierBar1P.value = 1;
        burrierBar2P.value = 1;
        xBottun1P.SetActive(false);
        xBottun2P.SetActive(false);

       //リスポーンタイマー
       respownPanel1P = GameObject.Find("Canvas/Canvas1P/RespownPanel");
        respownPanel2P = GameObject.Find("Canvas/Canvas2P/RespownPanel");
       
        respownTimerObj1P = GameObject.Find("Canvas/Canvas1P/RespownPanel/RespownTimer");
        respownTimerObj2P = GameObject.Find("Canvas/Canvas2P/RespownPanel/RespownTimer");
        respownTimerText1P = respownTimerObj1P.GetComponent<TextMeshProUGUI>();
        respownTimerText2P = respownTimerObj2P.GetComponent<TextMeshProUGUI>();

       
        respownPanel1P.SetActive(false);
        respownPanel2P.SetActive(false);

        //バフ
        buffSp1P.SetActive(false);
        buffFs1P.SetActive(false);
        buffG1P.SetActive(false);

        buffSp2P.SetActive(false);
        buffFs2P.SetActive(false);
        buffG2P.SetActive(false);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isFinish)
        {
            endSe.SetActive(true);
            if (sceneMoveFrame < 0)
            {
                sceneMoveFrame = 0;
                //シーン移動
                SceneManager.LoadScene("ResultScene");
            }
            sceneMoveFrame--;
            return;
        }
        PlayerDead1P();
        PlayerDead2P();
        if (playerScript1P.playerStock < 1 || playerScript2P.playerStock < 1)
        {
            normalBgm.SetActive(false);
            climaxBgm.SetActive(true);
        }
        //HPの変化を描画
        hpBar1P.value = playerScript1P.myHp / 100.0f;
        hpBar2P.value = playerScript2P.myHp / 100.0f;
        //ビームの描画
        beamBar1P.value = (float)(playerScript1P.beamGauge) / 100.0f;
        beamBar2P.value = (float)(playerScript2P.beamGauge) / 100.0f;
        if (beamBar1P.value < 1.0f)
        {
            beamText1P.text = "チャージ可能";
            beamMaxEff1P.SetActive(false);
        }
        else
        {
            beamText1P.text = "ビーム発射可能";
            beamMaxEff1P.SetActive(true);
        }
        if (beamBar2P.value < 1.0f)
        {
            beamText2P.text = "チャージ可能";
            beamMaxEff2P.SetActive(false);
        }
        else
        {
            beamText2P.text = "ビーム発射可能";
            beamMaxEff2P.SetActive(true);
        }


        burrierBar1P.value = 1.0f - (float)(playerScript1P.burrierCoolTime) / 1800.0f;
        burrierBar2P.value = 1.0f - (float)(playerScript2P.burrierCoolTime) / 1800.0f;
        if (burrierBar1P.value >= 1.0f)
        {
            xBottun1P.SetActive(true);
        }
        else
        {
            xBottun1P.SetActive(false);
        }

        if (burrierBar2P.value >= 1.0f)
        {
            xBottun2P.SetActive(true);
        }
        else
        {
            xBottun2P.SetActive(false);
        }

        //1Pバフ
        {
            if (playerScript1P.isBuffSp)
            {
                buffSp1P.SetActive(true);
            }
            else
            {
                buffSp1P.SetActive(false);
            }
            if (playerScript1P.isBuffFs)
            {
                buffFs1P.SetActive(true);
            }
            else
            {
                buffFs1P.SetActive(false);
            }
            if(playerScript1P.isBuffG)
            {
                buffG1P.SetActive(true);
            }
            else
            {
                buffG1P.SetActive(false);
            }
        }
        //2Pバフ
        {
            if (playerScript2P.isBuffSp)
            {
                buffSp2P.SetActive(true);
            }
            else
            {
                buffSp2P.SetActive(false);
            }
            if (playerScript2P.isBuffFs)
            {
                buffFs2P.SetActive(true);
            }
            else
            {
                buffFs2P.SetActive(false);
            }
            if (playerScript2P.isBuffG)
            {
                buffG2P.SetActive(true);
            }
            else
            {
                buffG2P.SetActive(false);
            }
        }

    }

    void PlayerDead1P()
    {
        if (playerScript1P.playerStock < 0)
        {
            //勝敗を書く
            gamesetPanel.SetActive(true);
            //gamesetPanel2P.SetActive(true);
            //gamesetText2P.text = "WIN";
            PlayerPrefs.SetInt("Winner", 2);
            isFinish = true;
            return;
        }
        if (playerScript1P.isDead)
        {
            respownPanel1P.SetActive(true);
            respawnTime1P--;
            respownTimerText1P.text = ((respawnTime1P / 60) + 1).ToString("d1");

            if (respawnTime1P < 0)//復活
            {
                respownPanel1P.SetActive(false);
                stockUi1P[playerScript1P.playerStock].SetActive(false);
                playerScript1P.isInvincibility = true;
                playerScript1P.myHp = 100;
                respawnTime1P = 180;
                playerObj1P.transform.position = respornPoint1.transform.position;
                playerScript1P.isDead = false;
            }
        }
    }
    void PlayerDead2P()
    {
        if (playerScript2P.playerStock < 0)
        {
            gamesetPanel.SetActive(true);
            //gamesetPanel2P.SetActive(true);
            //gamesetText1P.text = "WIN";
            PlayerPrefs.SetInt("Winner", 1);
            isFinish = true;
            return;
        }
        if (playerScript2P.isDead)
        {
            respawnTime2P--;
            respownPanel2P.SetActive(true);
            respownTimerText2P.text = ((respawnTime2P / 60) + 1).ToString("d1");

            if (respawnTime2P < 0)//復活
            {
                respownPanel2P.SetActive(false);
                stockUi2P[playerScript2P.playerStock].SetActive(false);
                playerScript2P.isInvincibility = true;
                playerScript2P.myHp = 100;
                respawnTime2P = 180;
                playerObj2P.transform.position = respornPoint2.transform.position;
                playerScript2P.isDead = false;
            }
        }
    }
}
