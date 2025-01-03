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
using System;


public class ModeSelectManager : MonoBehaviour
{
    //入力情報を取得する変数
    Vector2 inputSelect;

    //フェードインアウトをするためにこれらがいる
    [SerializeField] GameObject fadeManaObj;
    FadeManager fadeManager;
    //次に行くシーンの名前を保存するための変数
    private string sceneName;

    private float sizeChangeTime = 0;
    private float changeScale = 0f;
    private bool enlarge = false;

    //背景
    [SerializeField] private GameObject background;
    
    private Image backgroundColor;
    //モードセレクトのパーツども
    //0~4まである4が"ひとりで"
    int selectIndex = 3;//一人でから


    GameObject cursor;
    private Image cursorImage;
    GameObject centerLine;
    private Image centerLineImage;


    public float speed = 1.0f;
    private float time;
    private TextMeshProUGUI single;
    private TextMeshProUGUI multi;
    private TextMeshProUGUI option;
    private TextMeshProUGUI title;
    GameObject singleObj;
    GameObject multiObj;
    GameObject optionObj;
    GameObject titleObj;

    //画像
    [SerializeField] private GameObject[] modeImage = new GameObject[4];
    //se
    [SerializeField] private AudioClip[] seSound = new AudioClip[2];
    //public AudioClip beamSound;
    private AudioSource audioSource;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //ここでフェードインアウトのスクリプトを取得
        fadeManager = fadeManaObj.GetComponent<FadeManager>();
        //backgroundColor = background.GetComponent<Image>(); 
        cursor = GameObject.Find("Canvas/Cursor").gameObject;
        cursorImage = cursor.GetComponent<Image>();
        centerLine = GameObject.Find("Canvas/CenterLine").gameObject;
        centerLineImage = centerLine.GetComponent<Image>();

        singleObj = GameObject.Find("Canvas/Single").gameObject;
        multiObj = GameObject.Find("Canvas/Multi").gameObject;
        optionObj = GameObject.Find("Canvas/Option").gameObject;
        titleObj = GameObject.Find("Canvas/Title").gameObject;
        single = singleObj.GetComponent<TextMeshProUGUI>();
        multi = multiObj.GetComponent<TextMeshProUGUI>();
        option = optionObj.GetComponent<TextMeshProUGUI>();
        title =titleObj.GetComponent<TextMeshProUGUI>();

       

        ChangeImage(selectIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectIndex == 3)
        {
            cursor.transform.localPosition = new Vector3(0, 260, 0);
            //backgroundColor.color = new Color32(170, 41, 25, 255);
            cursorImage.color = new Color32(170, 41, 25, 255);
            centerLineImage.color = new Color32(170, 41, 25, 255);
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
                singleObj.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
            }
            else
            {
                sizeChangeTime -= Time.deltaTime;
                singleObj.transform.localScale -= new Vector3(changeScale, changeScale, changeScale);
            }
            //multi.color = GetTextColorAlpha(multi.color);

            //single.color = new Color32(0, 0, 0, 255);
            //tutorial.color = new Color32(0, 0, 0, 255);
            //option.color = new Color32(0, 0, 0, 255);
            //title.color = new Color32(0, 0, 0, 255);
           
        }
        else
        {
            singleObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
           
        }
        if (selectIndex == 2)
        {
            cursor.transform.localPosition = new Vector3(0, 87, 0);
            //backgroundColor.color = new Color32(25, 169, 146, 255);
            cursorImage.color = new Color32(25, 169, 146, 255);
            centerLineImage.color = new Color32(25, 169, 146, 255);
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
                multiObj.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
            }
            else
            {
                sizeChangeTime -= Time.deltaTime;
                multiObj.transform.localScale -= new Vector3(changeScale, changeScale, changeScale);
            }
        }
        else
        {
            multiObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (selectIndex == 1)
        {
            cursor.transform.localPosition = new Vector3(0, -85, 0);
            //backgroundColor.color = new Color32(75, 13, 115, 255);
            cursorImage.color = new Color32(75, 13, 115, 255);
            centerLineImage.color = new Color32(75, 13, 115, 255);
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
                optionObj.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
            }
            else
            {
                sizeChangeTime -= Time.deltaTime;
                optionObj.transform.localScale -= new Vector3(changeScale, changeScale, changeScale);
            }
        }
        else
        {
            optionObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (selectIndex == 0)
        {
            //title.color = GetTextColorAlpha(title.color);

            //single.color = new Color32(0, 0, 0, 255);
            //multi.color = new Color32(0, 0, 0, 255);
            //tutorial.color = new Color32(0, 0, 0, 255);
            //option.color = new Color32(0, 0, 0, 255);
            cursor.transform.localPosition = new Vector3(0, -270, 0);
            //backgroundColor.color = new Color32(50, 120, 100, 255);
            cursorImage.color = new Color32(0, 180, 20, 255);
            centerLineImage.color = new Color32(0, 180, 20, 255);
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
                titleObj.transform.localScale += new Vector3(changeScale, changeScale, changeScale);
            }
            else
            {
                sizeChangeTime -= Time.deltaTime;
                titleObj.transform.localScale -= new Vector3(changeScale, changeScale, changeScale);
            }
        }
        else
        {
            titleObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        ChangeImage(selectIndex);
        changeScale = Time.deltaTime * 0.1f;


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
    //Color GetTextColorAlpha(Color color)
    //{
    //    time += Time.deltaTime * speed * 5.0f;
    //    color.a = Mathf.Sin(time);

    //    return color;
    //}
    void ChangeImage(int Index)
    {
        for (int i = 0;i<4;++i)
        {
            modeImage[i].SetActive(false);
        }
        modeImage[Index].SetActive(true);
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
                audioSource.PlayOneShot(seSound[0]);
                selectIndex -= 1;
            }
            else if (inputSelect.y > 0.02f)
            {
                audioSource.PlayOneShot(seSound[0]);
                selectIndex += 1;
            }
           
        }

        if (selectIndex > 3)
        {
            selectIndex = 3;
        }
        if (selectIndex < 0)
        {
            selectIndex = 0;
        }
    }
    public void OnDecide(InputAction.CallbackContext context)
    {
        if (context.started) // ボタンを押したとき
        {
            if (selectIndex == 3)
            {
                audioSource.PlayOneShot(seSound[1]);
                sceneName = "SinglePlayScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 2)
            {
                audioSource.PlayOneShot(seSound[1]);
                sceneName = "TestScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 1)
            {
                audioSource.PlayOneShot(seSound[1]);
                sceneName = "OptionScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
            if (selectIndex == 0)
            {
                audioSource.PlayOneShot(seSound[1]);
                sceneName = "TitleScene";
                PlayerPrefs.SetString("SCENENAME", sceneName);
                fadeManager.isFadeIn = true;
            }
        }
    }
}
