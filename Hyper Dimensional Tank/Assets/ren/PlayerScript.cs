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

public class PlayerScript : MonoBehaviour
{
    //�v���C���[�̓���
    private float moveSpeed = 5f;
    private Vector3 moveVec;
   
    private Rigidbody rb;
    //float inputVertical;
    //float inputHorizontal;

    private float bodyRotateSpeed = 50f;
    private float headRotateSpeed = 50f;
    //Vector3 moveSpeed = new Vector3(0, 0, 1f);
    //float moveSpeed = 5f;
    Transform head;

    //�e�̓���
    //�e�̔��ˏꏊ
    public GameObject shotPoint;

    //�e
    public GameObject bullet;

    //�e�̑���
    private float bulletSpeed = 200f;

    //�N�[���^�C��
    private int countCoolTime = 0;
    private int shotCoolTime = 60;
    private bool isShot = true;

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
        PlayerMove();

        if (isShot)
        {
            countCoolTime = 0;
            if (playerControl.Player.Fire.triggered)//�����ꂽ�u��
            {
                //�e�̔��˂���ꏊ���擾����
                Vector3 bulletPosition = shotPoint.transform.position;
                //
                GameObject newBullet = Instantiate(bullet, bulletPosition, head.gameObject.transform.rotation);
                Vector3 dir = newBullet.transform.forward;
                newBullet.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
                isShot = false;
            }
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    //�e�̔��˂���ꏊ���擾����
            //    Vector3 bulletPosition = shotPoint.transform.position;
            //    //
            //    GameObject newBullet = Instantiate(bullet, bulletPosition, head.gameObject.transform.rotation);
            //    Vector3 dir = newBullet.transform.forward;
            //    newBullet.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
            //    isShot = false;
            //}
        }
        else
        {
            if(countCoolTime > shotCoolTime)
            {
                isShot = true;
            }
            countCoolTime++;
        }

       

    }
    //private void OnEnable()
    //{
    //    // �S�̂�Action��L����
    //    playerControl.Enable();
    //}

    //private void OnDisable()
    //{
    //    // �S�̂�Action�𖳌���
    //    playerControl.Disable();
    //}
    public void OnFire(InputAction.CallbackContext context)
    {
        print("Fire Action���Ă΂ꂽ�I");
    }
    public void OnForward(InputAction.CallbackContext context)
    {
        this.transform.Translate(moveVec * Time.deltaTime);
    }
    public void OnBackward(InputAction.CallbackContext context)
    {
        this.transform.Translate(-moveVec * Time.deltaTime);
    }
    public void OnBodyRotationRight(InputAction.CallbackContext context)
    {
        // Quaternion.AngleAxis(�x���@, ��);
        this.transform.rotation *= Quaternion.AngleAxis(bodyRotateSpeed * Time.deltaTime, Vector3.up);
    }
    public void OnBodyRotationLeft(InputAction.CallbackContext context)
    {
        // Quaternion.AngleAxis(�x���@, ��);
        this.transform.rotation *= Quaternion.AngleAxis(-bodyRotateSpeed * Time.deltaTime, Vector3.up);
    }

    private void PlayerMove()
    {

        //�O�i�ƌ��
        //if (playerControl.Player.Forward.IsPressed())//������Ă����
        //{
        //    this.transform.Translate(moveVec * Time.deltaTime);
        //}

        //if (playerControl.Player.Backward.IsPressed())//������Ă����
        //{
        //    this.transform.Translate(-moveVec * Time.deltaTime);
        //}
        //��]
        //if (playerControl.Player.BodyRotationRight.IsPressed())//������Ă����
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    this.transform.rotation *= Quaternion.AngleAxis(bodyRotateSpeed * Time.deltaTime, Vector3.up);
        //}
        //if (playerControl.Player.BodyRotationLeft.IsPressed())//������Ă����
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    this.transform.rotation *= Quaternion.AngleAxis(-bodyRotateSpeed * Time.deltaTime, Vector3.up);
        //}

        //��C�̌����̉�]
        //ActionMaps/Action/���͂̂ӂ�܂�
        if (playerControl.Player.HeadRotationLeft.IsPressed())//������Ă����
        {
            //Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(-headRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (playerControl.Player.HeadRotationRight.IsPressed())//������Ă����
        {
            //Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        }



        //inputVertical = Input.GetAxis("Vertical");
        //inputHorizontal = Input.GetAxis("Horizontal");

        //this.transform.Translate(0,0, inputVertical * Time.deltaTime);
        //this.transform.rotation *= Quaternion.AngleAxis(inputHorizontal * bodyRotateSpeed * Time.deltaTime, Vector3.up);

        //if (Input.GetKeyDown(KeyCode.Joystick2Button14))
        //{
        //    head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        //}





        //if (Input.GetKey(KeyCode.W))
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    this.transform.Translate(moveSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    this.transform.Translate(-moveSpeed * Time.deltaTime);
        //}


        //if (Input.GetKey(KeyCode.D))
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    this.transform.rotation *= Quaternion.AngleAxis(bodyRotateSpeed * Time.deltaTime, Vector3.up);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    this.transform.rotation *= Quaternion.AngleAxis(-bodyRotateSpeed * Time.deltaTime, Vector3.up);
        //}


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    // Quaternion.AngleAxis(�x���@, ��);
        //    head.rotation *= Quaternion.AngleAxis(-headRotateSpeed * Time.deltaTime, Vector3.up);
        //}


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            myHp -= 30;
            Debug.Log(myHp);
        }

        if(myHp <= 0)
        {
            isDead = true;
            playerStock--;
        }
    }
}
