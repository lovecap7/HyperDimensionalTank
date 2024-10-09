using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;         //追尾 オブジェクト
    public Vector2 rotationSpeed;           //回転速度
   // private Vector3 lastMousePosition;      //最後のマウス座標
    private Vector3 lastTargetPosition;     //最後の追尾オブジェクトの座標

    private Vector2 inputMove;
    private bool isCameraMove = false;

    // Start is called before the first frame update
    void Start()
    {
        //lastMousePosition = Input.mousePosition;
        lastTargetPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        //Zoom();
    }

    void Rotate()
    {
        transform.position += Player.transform.position - lastTargetPosition;
        lastTargetPosition = Player.transform.position;

        if (isCameraMove)
        {

            //Vector3 nowMouseValue = Input.mousePosition - lastMousePosition;

            var newAngle = Vector3.zero;
            newAngle.x = rotationSpeed.x * inputMove.x * Time.deltaTime;
            //newAngle.y = rotationSpeed.y * nowMouseValue.y;

            transform.RotateAround(Player.transform.position, Vector3.up, newAngle.x);
            //transform.RotateAround(Player.transform.position, transform.right, -newAngle.y);
        }

        //lastMousePosition = Input.mousePosition;
    }

    public void OnCameraMoveRight(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        inputMove = new Vector2(50.0f,0);
        if (context.started) // ボタンを押したとき
        {
            isCameraMove = true;
        }
        else if (context.canceled) // ボタンを離したとき
        {
            isCameraMove = false;
        }
    }

    public void OnCameraMoveLeft(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        inputMove = new Vector2(-50.0f, 0);
        if (context.started) // ボタンを押したとき
        {
            isCameraMove = true;
        }
        else if (context.canceled) // ボタンを離したとき
        {
            isCameraMove = false;
        }
    }

    //拡大縮小
    //void Zoom()
    //{
    //    zoom = Input.GetAxis("Mouse ScrollWheel");
    //    Vector3 offset = new Vector3(0, 0, 0);
    //    Vector3 pos = Player.transform.position - transform.position;

    //    if (zoom > 0)
    //    {
    //        offset = pos.normalized * 1;
    //    }
    //    else if (zoom < 0)
    //    {
    //        offset = -pos.normalized * 1;

    //    }
    //    transform.position = transform.position + offset;
    //}

}
