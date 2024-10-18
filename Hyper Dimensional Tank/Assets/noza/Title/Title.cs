using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.Properties;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;

public class Title : MonoBehaviour
{
    //���͏��擾
    private Vector2 inputValue;

    
    public float speed = 0.1f;
    private float time;
    //private TextMeshProUGUI gameStartText; 
    GameObject gameStartTextObj;
    // GameObject fadePanel;

    //�t�F�[�h�C���A�E�g�����邽�߂ɂ���炪����
    [SerializeField] GameObject fadeManaObj;
     FadeManager fadeManager;
    //���ɍs���V�[���̖��O��ۑ����邽�߂̕ϐ�
    private string sceneName;

    private float sizeChangeTime = 0;
    private float changeScale= 0f;
    private bool enlarge = false;

    // Start is called before the first frame update
    void Start()
    {
        gameStartTextObj = GameObject.Find("Canvas/GameStartText").gameObject;
        //gameStartText = gameStartTextObj.GetComponent<TextMeshProUGUI>();

        //�����Ńt�F�[�h�C���A�E�g�̃X�N���v�g���擾
        fadeManager = fadeManaObj.GetComponent<FadeManager>();
        // fadePanel = GameObject.Find("Canvas/Panel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //gameStartText.color = GetTextColorAlpha(gameStartText.color);
        changeScale = Time.deltaTime * 0.1f;

        if (sizeChangeTime < 0)
        {
            enlarge = true;
        }
        if (sizeChangeTime > 1f)
        {
            enlarge = false;
        }

        if (enlarge == true)
        {
            sizeChangeTime += Time.deltaTime;
            gameStartTextObj.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
        }
        else
        {
            sizeChangeTime -= Time.deltaTime;
            gameStartTextObj.transform.localScale -= new Vector3(changeScale, changeScale, changeScale);
        }
        // W�L�[����������cursorNum��1���
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    cursorNum = 1;
        //    cursor.transform.localPosition = new Vector3(-200,-161,0);
        //}
        //// S�L�[����������cursorNum��2���
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    cursorNum = 2;
        //    cursor.transform.localPosition = new Vector3(-200, -253, 0);

        //}
        //if (cursorNum == 1)
        //{

        //}
        //if (cursorNum == 2)
        //{
        //    optionText.color = GetTextColorAlpha(optionText.color);
        //    gameStartText.color = new Color32(0,0,0,255);
        //}

        // �X�y�[�X�L�[�������ꂽ�猈��
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (cursorNum == 1)
        //    {
        //        //SceneManager.LoadScene("ModeSelectScene");
        //        sceneName = "ModeSelectScene";
        //        PlayerPrefs.SetString("SCENENAME", sceneName);
        //        fadeManager.isFadeIn = true;
        //    }
        //    if (cursorNum == 2)
        //    {
        //        //Debug.Log("�I�v�V����");
        //        sceneName = "OptionScene";
        //        PlayerPrefs.SetString("SCENENAME", sceneName);
        //        fadeManager.isFadeIn = true;
        //    }
        //}


    }

    //���������Ȃ񂩂Ŏg���Ă�������
    //Color GetTextColorAlpha(Color color)
    //{
    //    time += Time.deltaTime * speed * 20.0f;
    //    color.a = Mathf.Sin(time);

    //    return color;
    //}

    //public void OnSelect(InputAction.CallbackContext context)
    //{
    //    // ���͒l��ێ����Ă���
    //    inputValue = context.ReadValue<Vector2>();

    //}
    public void OnDecide(InputAction.CallbackContext context)
    {
        if (context.started) // �{�^�����������Ƃ�
        {
            sceneName = "ModeSelectScene";
            PlayerPrefs.SetString("SCENENAME", sceneName);
            fadeManager.isFadeIn = true;
        }
    }


}
