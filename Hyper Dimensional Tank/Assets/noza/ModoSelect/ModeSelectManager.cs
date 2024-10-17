using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using TMPro;
using Unity.Properties;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;


public class ModeSelectManager : MonoBehaviour
{
    //入力情報を取得する変数
    Vector2 inputSelect;

    //フェードインアウトをするためにこれらがいる
    [SerializeField] GameObject fadeManaObj;
    FadeManager fadeManager;
    //次に行くシーンの名前を保存するための変数
    private string sceneName;

    //背景
    [SerializeField] private GameObject background;
    private Image backgroundColor;
    //モードセレクトのパーツども
    int selectIndex = 5;
    GameObject cursor;
    public float speed = 1.0f;
    private float time;
    private TextMeshProUGUI single;
    private TextMeshProUGUI multi;
    private TextMeshProUGUI tutorial;
    private TextMeshProUGUI option;
    private TextMeshProUGUI title;
    GameObject singleObj;
    GameObject multiObj;
    GameObject tutorialObj;
    GameObject optionObj;
    GameObject titleObj;
    //float alfa;
    //float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        //ここでフェードインアウトのスクリプトを取得
        fadeManager = fadeManaObj.GetComponent<FadeManager>();
        backgroundColor = background.GetComponent<Image>(); 

        singleObj = GameObject.Find("Canvas/Single").gameObject;
        multiObj = GameObject.Find("Canvas/Multi").gameObject;
        tutorialObj = GameObject.Find("Canvas/Tutorial").gameObject;
        optionObj = GameObject.Find("Canvas/Option").gameObject;
        titleObj = GameObject.Find("Canvas/Title").gameObject;
        single = singleObj.GetComponent<TextMeshProUGUI>();
        multi = multiObj.GetComponent<TextMeshProUGUI>();
        tutorial = tutorialObj.GetComponent<TextMeshProUGUI>();
        option = optionObj.GetComponent<TextMeshProUGUI>();
        title =titleObj.GetComponent<TextMeshProUGUI>();

        cursor = GameObject.Find("Canvas/Cursor").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectIndex == 5)
        {
            single.color = GetTextColorAlpha(single.color);

            multi.color = new Color32(0, 0, 0, 255);
            tutorial.color = new Color32(0, 0, 0, 255);
            option.color = new Color32(0, 0, 0, 255);
            title.color = new Color32(0, 0, 0, 255);
            cursor.transform.localPosition = new Vector3(-500, 260, 0);
            backgroundColor.color = new Color32(170, 41, 25, 255);
        }
        if (selectIndex == 4)
        {
            multi.color = GetTextColorAlpha(multi.color);

            single.color = new Color32(0, 0, 0, 255);
            tutorial.color = new Color32(0, 0, 0, 255);
            option.color = new Color32(0, 0, 0, 255);
            title.color = new Color32(0, 0, 0, 255);
            cursor.transform.localPosition = new Vector3(-500, 130, 0);
            backgroundColor.color = new Color32(25, 169, 146, 255);
        }
        if (selectIndex == 3)
        {
            tutorial.color = GetTextColorAlpha(tutorial.color);

            single.color = new Color32(0, 0, 0, 255);
            multi.color = new Color32(0, 0, 0, 255);
            option.color = new Color32(0, 0, 0, 255);
            title.color = new Color32(0, 0, 0, 255);
            cursor.transform.localPosition = new Vector3(-500, 0, 0);
            backgroundColor.color = new Color32(169, 143, 25, 255);
        }
        if (selectIndex == 2)
        {
            option.color = GetTextColorAlpha(option.color);

            single.color = new Color32(0, 0, 0, 255);
            multi.color = new Color32(0, 0, 0, 255);
            tutorial.color = new Color32(0, 0, 0, 255);
            title.color = new Color32(0, 0, 0, 255);
            cursor.transform.localPosition = new Vector3(-500, -120, 0);
            backgroundColor.color = new Color32(75, 13, 115, 255);
        }
        if (selectIndex == 1)
        {
            title.color = GetTextColorAlpha(title.color);

            single.color = new Color32(0, 0, 0, 255);
            multi.color = new Color32(0, 0, 0, 255);
            tutorial.color = new Color32(0, 0, 0, 255);
            option.color = new Color32(0, 0, 0, 255);
            cursor.transform.localPosition = new Vector3(-500, -250, 0);
            backgroundColor.color = new Color32(50, 120, 100, 255);
        }
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    cursorNum++;

        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    cursorNum--;

        //}
        //if (cursorNum == 1)
        //{
        //    title.color = GetTextColorAlpha(title.color);
        //    single.color = new Color32(0, 0, 0, 255);
        //    multi.color = new Color32(0, 0, 0, 255);
        //    cursor.transform.localPosition = new Vector3(-210, -144, 0);
        //}
        //if (cursorNum == 2)
        //{
        //    multi.color = GetTextColorAlpha(multi.color);
        //    title.color = new Color32(0, 0, 0, 255);
        //    single.color = new Color32(0, 0, 0, 255);
        //    cursor.transform.localPosition = new Vector3(-300, -38, 0);
        //}
        //if (cursorNum == 3)
        //{
        //    single.color = GetTextColorAlpha(single.color);
        //    multi.color = new Color32(0, 0, 0, 255);
        //    title.color = new Color32(0, 0, 0, 255);
        //    cursor.transform.localPosition = new Vector3(-363, 66, 0);
        //}
        //// スペースキーが押されたら決定
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (cursorNum == 3)
        //    {
        //        Debug.Log("ひとりで");
        //    }
        //    if (cursorNum == 2)
        //    {
        //        SceneManager.LoadScene("TestScene");


        //    }
        //    if (cursorNum == 1)
        //    {
        //        SceneManager.LoadScene("TitleScene");
        //    }
        //}
        //if (cursorNum >= 4)
        //{
        //    cursorNum = 3;
        //}
        //if (cursorNum <= 0)
        //{
        //    cursorNum = 1;
        //}
    }
    Color GetTextColorAlpha(Color color)
    {
        time += Time.deltaTime * speed * 5.0f;
        color.a = Mathf.Sin(time);

        return color;
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        inputSelect = context.ReadValue<Vector2>();
        if (context.started) // ボタンを押したとき
        {
            Debug.Log(inputSelect);
            if (inputSelect.y < -0.02f)
            {
                selectIndex -= 1;
            }
            else if (inputSelect.y > 0.02f)
            {
                selectIndex += 1;
            }

        }

        if (selectIndex > 5)
        {
            selectIndex = 5;
        }
        if (selectIndex < 1)
        {
            selectIndex = 1;
        }
    }
    public void OnDecide(InputAction.CallbackContext context)
    {
        if (context.started) // ボタンを押したとき
        {
            if (selectIndex == 5)
            {
                sceneName = "TestScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 4)
            {
                sceneName = "TestScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 3)
            {
                sceneName = "TestScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 2)
            {
                sceneName = "OptionScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 1)
            {
                sceneName = "TitleScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
        }
    }
}
