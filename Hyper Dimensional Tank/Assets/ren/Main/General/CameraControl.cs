using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;         //�ǔ� �I�u�W�F�N�g
    public Vector2 rotationSpeed;           //��]���x
   // private Vector3 lastMousePosition;      //�Ō�̃}�E�X���W
    private Vector3 lastTargetPosition;     //�Ō�̒ǔ��I�u�W�F�N�g�̍��W

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
        // ���͒l��ێ����Ă���
        inputMove = new Vector2(50.0f,0);
        if (context.started) // �{�^�����������Ƃ�
        {
            isCameraMove = true;
        }
        else if (context.canceled) // �{�^���𗣂����Ƃ�
        {
            isCameraMove = false;
        }
    }

    public void OnCameraMoveLeft(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        inputMove = new Vector2(-50.0f, 0);
        if (context.started) // �{�^�����������Ƃ�
        {
            isCameraMove = true;
        }
        else if (context.canceled) // �{�^���𗣂����Ƃ�
        {
            isCameraMove = false;
        }
    }

    //�g��k��
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
