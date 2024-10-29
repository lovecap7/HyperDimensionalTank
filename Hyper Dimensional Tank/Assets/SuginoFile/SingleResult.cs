using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SingleResult : MonoBehaviour
{
    // Start is called before the first frame update
   
    private bool isSelect = false;



   



    //どちらを選択しているかを変数で管理
    private int selectIndex = 1;

    [SerializeField] private GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        cursor.transform.localPosition = new Vector3(-200, -150, 0);
    }
    
    public void OnSelect(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        Vector2 inputStick = context.ReadValue<Vector2>();
        if (inputStick.x < -0.5f)
        {
            selectIndex = 1;
            cursor.transform.localPosition = new Vector3(-200, -150, 0);
        }
        if (inputStick.x > 0.5f)
        {
            selectIndex = 2;
            cursor.transform.localPosition = new Vector3(200, -150, 0);
        }
    }

    public void OnDicide(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (selectIndex == 1)
            {
                //シーン移動
                SceneManager.LoadScene("SinglePlayScene");
            }
            else
            {
                //シーン移動
                SceneManager.LoadScene("ModeSelectScene");
            }
        }
    }
}


