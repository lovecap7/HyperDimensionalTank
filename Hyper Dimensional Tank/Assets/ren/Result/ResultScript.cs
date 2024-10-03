using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class ResultScript : MonoBehaviour
{
    [SerializeField] private GameObject player1P;
    [SerializeField] private GameObject player2P;
    private int winPlayerIndex;
    private GameObject winTextObj;
    private TextMeshProUGUI winText;



    //どちらを選択しているかを変数で管理
    private int selectIndex = 1;

    [SerializeField] private GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        winPlayerIndex = PlayerPrefs.GetInt("Winner", 0);
        winTextObj = GameObject.Find("Canvas/WinText");
        winText = winTextObj.GetComponent<TextMeshProUGUI>();
        if(winPlayerIndex == 1)
        {
            winText.text = "1P WIN!!";
            Instantiate(player1P, new Vector3(0,3,-5), Quaternion.identity);
        }
        else if (winPlayerIndex == 2)
        {
            winText.text = "2P WIN!!";
            Instantiate(player2P, new Vector3(0, 3, -5), Quaternion.identity);
        }
        else
        {
            winText.text = "error";
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(selectIndex == 1)
        {
            Debug.Log("左");
        }
        else
        {
            Debug.Log("右");
        }
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        Vector2 inputStick = context.ReadValue<Vector2>();
        if (inputStick.x < -0.5f)
        {
            selectIndex = 1;
        }
        if (inputStick.x > 0.5f)
        {
            selectIndex = 2;
        }
    }
}
