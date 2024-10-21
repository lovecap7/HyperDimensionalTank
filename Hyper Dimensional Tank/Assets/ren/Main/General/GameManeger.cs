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
    //�r�[�������܂��Ă��邩�ǂ������e�L�X�g�ŕ\��
    [SerializeField] private GameObject beamTextObj1P;
    [SerializeField] private GameObject beamTextObj2P;
    private TextMeshProUGUI beamText1P;
    private TextMeshProUGUI beamText2P;
    //�c�@
    [SerializeField] private GameObject[] stockUi1P;
    [SerializeField] private GameObject[] stockUi2P;

    //burrierUI
    [SerializeField] private Slider burrierBar1P;
    [SerializeField] private Slider burrierBar2P;
  

    //X�{�^���̕\��
    [SerializeField] private GameObject xBottun1P;
    [SerializeField] private GameObject xBottun2P;


   //���X��
   private int respawnTime1P = 180;
    private int respawnTime2P = 180;
    private GameObject respownPanel1P;
    private GameObject respownPanel2P;
    private GameObject respownTimerObj1P;
    private GameObject respownTimerObj2P;
    private TextMeshProUGUI respownTimerText1P;
    private TextMeshProUGUI respownTimerText2P;



    //���X�n
    [SerializeField] private GameObject respornPoint1;
    [SerializeField] private GameObject respornPoint2;

    //�������v���C���[�̔ԍ���ۑ��@1P��1 2P��2
    private int winPlayerIndex = 0;
    //�Q�[���I���t���O
    private bool isFinish = false;
    [SerializeField] private GameObject endSe;
    //���b��������V�[���ړ�
    private int sceneMoveFrame = 90;

    [SerializeField]private GameObject normalBgm;
    [SerializeField]private GameObject climaxBgm;

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60;
        playerObj1P = GameObject.Find("Player1");
        playerObj2P = GameObject.Find("Player2");
        playerScript1P = playerObj1P.GetComponent<PlayerScript>();
        playerScript2P = playerObj2P.GetComponent<PlayerScript>();

        //HP�o�[��MAX��
        hpBar1P.value = 1;
        hpBar2P.value = 1;
        //�r�[���̃Q�[�W��0��
        beamBar1P.value = 0;
        beamBar2P.value = 0;
        beamText1P = beamTextObj1P.GetComponent<TextMeshProUGUI>();
        beamText2P = beamTextObj2P.GetComponent<TextMeshProUGUI>();
        //�o���A��MAX��
        burrierBar1P.value = 1;
        burrierBar2P.value = 1;
        xBottun1P.SetActive(false);
        xBottun2P.SetActive(false);

       //���X�|�[���^�C�}�[
       respownPanel1P = GameObject.Find("Canvas/Canvas1P/RespownPanel");
        respownPanel2P = GameObject.Find("Canvas/Canvas2P/RespownPanel");
       
        respownTimerObj1P = GameObject.Find("Canvas/Canvas1P/RespownPanel/RespownTimer");
        respownTimerObj2P = GameObject.Find("Canvas/Canvas2P/RespownPanel/RespownTimer");
        respownTimerText1P = respownTimerObj1P.GetComponent<TextMeshProUGUI>();
        respownTimerText2P = respownTimerObj2P.GetComponent<TextMeshProUGUI>();

       
        respownPanel1P.SetActive(false);
        respownPanel2P.SetActive(false);

     
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinish)
        {
            endSe.SetActive(true);
            if (sceneMoveFrame < 0)
            {
                sceneMoveFrame = 0;
                //�V�[���ړ�
                SceneManager.LoadScene("ResultScene");
            }
            sceneMoveFrame--;
            return;
        }
        if (playerScript1P.playerStock < 0)
        {
            //���s������
            //gamesetPanel1P.SetActive(true);
            //gamesetPanel2P.SetActive(true);
            playerObj1P.SetActive(false);
            //gamesetText2P.text = "WIN";
            PlayerPrefs.SetInt("Winner", 2);
            isFinish = true;
            return;
        }
        if (playerScript1P.isDead)
        {
           
            playerObj1P.SetActive(false);
            respownPanel1P.SetActive(true);
            respawnTime1P--;
            respownTimerText1P.text = ((respawnTime1P / 60) + 1).ToString("d1");

            if (respawnTime1P < 0)//����
            {
                respownPanel1P.SetActive(false);
                stockUi1P[playerScript1P.playerStock].SetActive(false);
                playerScript1P.isDead = false;
                playerScript1P.isInvincibility = true;
                playerScript1P.myHp = 100;
                playerScript1P.beamGauge += 50;
                playerObj1P.SetActive(true);
                respawnTime1P = 180;
                playerObj1P.transform.position = respornPoint1.transform.position;
            }
        }

        if (playerScript2P.playerStock < 0)
        {
            //gamesetPanel1P.SetActive(true);
            //gamesetPanel2P.SetActive(true);
            playerObj2P.SetActive(false);
            //gamesetText1P.text = "WIN";
            PlayerPrefs.SetInt("Winner", 1);
            isFinish = true;
            return;
        }
        if (playerScript2P.isDead)
        {
           
            playerObj2P.SetActive(false);
            respownPanel2P.SetActive(true);
            respawnTime2P--;
            respownTimerText2P.text = ((respawnTime2P / 60) + 1).ToString("d1");

            if (respawnTime2P < 0)//����
            {
                respownPanel2P.SetActive(false);
                stockUi2P[playerScript2P.playerStock].SetActive(false);
                playerScript2P.isDead = false;
                playerScript2P.isInvincibility = true;
                playerScript2P.myHp = 100;
                playerScript2P.beamGauge += 50;
                playerObj2P.SetActive(true);
                respawnTime2P = 180;
                playerObj2P.transform.position = respornPoint2.transform.position;
            }
        }

        if (playerScript1P.playerStock < 1 || playerScript2P.playerStock < 1)
        {
            normalBgm.SetActive(false);
            climaxBgm.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        //HP�̕ω���`��
        hpBar1P.value = playerScript1P.myHp / 100.0f;
        hpBar2P.value = playerScript2P.myHp / 100.0f;
        //�r�[���̕`��
        beamBar1P.value = (float)(playerScript1P.beamGauge) / 100.0f;
        beamBar2P.value = (float)(playerScript2P.beamGauge) / 100.0f;
        if (beamBar1P.value < 1.0f)
        {
            beamText1P.text = "�`���[�W�\";
        }
        else
        {
            beamText1P.text = "�r�[�����ˉ\";
        }
        if (beamBar2P.value < 1.0f)
        {
            beamText2P.text = "�`���[�W�\";
        }
        else
        {
            beamText2P.text = "�r�[�����ˉ\";
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
    }
}
