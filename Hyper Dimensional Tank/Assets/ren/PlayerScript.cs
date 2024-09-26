using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Transactions;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerScript : MonoBehaviour
{
    //�v���C���[�̓���
    private float moveSpeed = 5f;
    private Vector3 moveVec;
    private Vector2 inputMove;
    private float inputButton;

    private bool isLeft = false;
    private bool isRight = false;

    private float bodyRotateSpeed = 50f;
    private float headRotateSpeed = 50f;
    //Vector3 moveSpeed = new Vector3(0, 0, 1f);
    //float moveSpeed = 5f;
    Transform head;

    //�e�̓���
    //�e�̔��ˏꏊ
    public GameObject shotPoint;

    //�e
    public GameObject bulletNomal;
    public GameObject bulletStrong;

    //�e�̑���
    private float bulletSpeed = 400f;

    //�N�[���^�C��
    private int nomalCountTime = 0;
    private int canNomalCoolTime = 60;
    private int strongCountTime = 0;
    private int canStrongCoolTime = 90;

    private bool isShotNomal = true;
    private bool isShotStrong = true;

    //�̗�
    public int myHp = 100;
    public bool isDead = false;
    public int playerStock = 2;



    //InputSystem
   private PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        moveVec = new Vector3(0,0,moveSpeed);
        head = transform.GetChild(0);
        playerControl = new PlayerControl();
        playerControl.Enable();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (isDead)
        {
            return;
        }
     
        nomalCountTime++;
        if (nomalCountTime > canNomalCoolTime)
        {
            isShotNomal = true;
        }

        strongCountTime++;
        if (strongCountTime > canStrongCoolTime)
        {
            isShotStrong = true;
        }

        this.transform.Translate(inputMove.y * moveVec * Time.deltaTime);
        //Quaternion.AngleAxis(�x���@, ��);
        this.transform.rotation *= Quaternion.AngleAxis(inputMove.x * bodyRotateSpeed * Time.deltaTime, Vector3.up);
        
        if (isLeft)
        {
            //Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(-headRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (isRight)
        {
            //Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        }

        //isLeft = false;
        //isRight = false;
    }
 
    public void OnShotNomal(InputAction.CallbackContext context)
    {
        if (isShotNomal)
        {
            //�e�̔��˂���ꏊ���擾����
            Vector3 bulletPosition = shotPoint.transform.position;
            //
            GameObject newBullet = Instantiate(bulletNomal, bulletPosition, head.gameObject.transform.rotation);
            Vector3 dir = newBullet.transform.forward;
            newBullet.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
            nomalCountTime = 0;
            isShotNomal = false;
        }
    }
    public void OnShotStrong(InputAction.CallbackContext context)
    {
        if (isShotStrong)
        {
            //�e�̔��˂���ꏊ���擾����
            Vector3 bulletPosition = shotPoint.transform.position;
            //
            GameObject newBullet = Instantiate(bulletStrong, bulletPosition, head.gameObject.transform.rotation);
            Vector3 dir = newBullet.transform.forward;
            newBullet.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
            strongCountTime = 0;
            isShotStrong = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        inputMove = context.ReadValue<Vector2>();
     
    }

    public void HeadRotationLeft(InputAction.CallbackContext context)
    {
        if (context.started) // �{�^�����������Ƃ�
        {
            isLeft = true;
        }
        else if (context.canceled) // �{�^���𗣂����Ƃ�
        {
            isLeft = false;
        }
    }

    public void HeadRotationRight(InputAction.CallbackContext context)
    {
        if (context.started) // �{�^�����������Ƃ�
        {
            isRight = true;
        }
        else if (context.canceled) // �{�^���𗣂����Ƃ�
        {
            isRight = false;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            myHp -= 5;
        }
        if (other.gameObject.tag == "BigBullet")
        {
            myHp -= 30;
        }

        if (myHp <= 0)
        {
            isDead = true;
            playerStock--;
        }
    }
}
