using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.Properties;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    int cursorNum = 1;
    GameObject cursor;
    public float speed = 1.0f;
    private float time;
    private TextMeshProUGUI gameStartText; 
    private TextMeshProUGUI optionText; 
    GameObject gameStartTextObj;
    GameObject optionTextObj;
    // GameObject fadePanel;

    //�t�F�[�h�C���A�E�g�����邽�߂ɂ���炪����
    [SerializeField] GameObject fadeManaObj;
     FadeManager fadeManager;
    //���ɍs���V�[���̖��O��ۑ����邽�߂̕ϐ�
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        gameStartTextObj = GameObject.Find("Canvas/GameStartText").gameObject;
        optionTextObj = GameObject.Find("Canvas/OptionText").gameObject;
        cursor = GameObject.Find("Canvas/Cursor").gameObject;
        gameStartText = gameStartTextObj.GetComponent<TextMeshProUGUI>();
        optionText = optionTextObj.GetComponent<TextMeshProUGUI>();

        //�����Ńt�F�[�h�C���A�E�g�̃X�N���v�g���擾
        fadeManager = fadeManaObj.GetComponent<FadeManager>();
        // fadePanel = GameObject.Find("Canvas/Panel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // W�L�[����������cursorNum��1���
        if (Input.GetKeyDown(KeyCode.W))
        {
            cursorNum = 1;
            cursor.transform.localPosition = new Vector3(-200,-161,0);
        }
        // S�L�[����������cursorNum��2���
        if (Input.GetKeyDown(KeyCode.S))
        {
            cursorNum = 2;
            cursor.transform.localPosition = new Vector3(-200, -253, 0);

        }
        if (cursorNum == 1)
        {
            gameStartText.color = GetTextColorAlpha(gameStartText.color);
            optionText.color = new Color32(0, 0, 0, 255);
        }
        if (cursorNum == 2)
        {
            optionText.color = GetTextColorAlpha(optionText.color);
            gameStartText.color = new Color32(0,0,0,255);
        }

        // �X�y�[�X�L�[�������ꂽ�猈��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cursorNum == 1)
            {
                //SceneManager.LoadScene("ModeSelectScene");
                sceneName = "ModeSelectScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (cursorNum == 2)
            {
                //Debug.Log("�I�v�V����");
                sceneName = "OptionScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
        }

        
    }

    Color GetTextColorAlpha(Color color)
    {
        time += Time.deltaTime * speed * 5.0f;
        color.a = Mathf.Sin(time);

        return color;
    }

    
}
