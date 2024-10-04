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
    public string playerIndex;

    //�v���C���[�̓���
    private float moveSpeed = 20f;
    private float tempSpeed = 0f;
    //private Vector3 moveVec;
    private Vector2 inputMove;
    private Rigidbody playerRb;

    private bool isLeft = false;
    private bool isRight = false;

    private float bodyRotateSpeed = 50f;
    private float headRotateSpeed = 50f;
    //Vector3 moveSpeed = new Vector3(0, 0, 1f);
    //float moveSpeed = 5f;
    private Transform head;

    //�e�̓���
    //�e�̔��ˏꏊ
    [SerializeField] private GameObject shotPoint;

    //�e
    [SerializeField] private GameObject bulletNomal;
    [SerializeField] private GameObject bulletStrong;
   

    //�e�̑���
    private float nomalBulletSpeed = 600f;
    private float strongBulletSpeed = 400f;

    //�̗� public�ł悢
    public int myHp = 100;
    public bool isDead = false;
    public int playerStock = 2;

    //���������Ƃ��ɖ��G  public OK
    public bool isInvincibility = false;
    private int countInvincibility = 0; //���G���Ԃ܂Ő�����
    private int invincibilityTime = 180;  //���G���Ԃ̃t���[���� //3�b

    //���G��������
    [SerializeField] private GameObject headObj;
    Color32 colorOrigin = new Color32(255, 255, 255, 1);
    Color32 colorChange = new Color32(50, 50, 50, 1);

    //����
    [SerializeField] private GameObject deadExplosion = null;


    //�N�[���^�C��
    private int coolTime;
    private int canCoolTime = 60;

    private bool isShotNomal = true;
    private bool isShotStrong = true;
    //�r�[��(�K�E�Z)
    [SerializeField] private GameObject bulletBeam;
    private bool isShotBeam = false;
    public float beamGauge = 0;
    private bool isCharge = false;
    //�r�[���̑S�̃t���[��
    private int beamFream = 120;
    private int beamFreamCount = 0;
    private bool isBeamCount = false;

    //InputSystem
    private PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.transform.GetComponent<Rigidbody>();
        //moveVec = new Vector3(0,0,moveSpeed);
        head = transform.GetChild(0);
        playerControl = new PlayerControl();
        playerControl.Enable();
        tempSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (isDead)
        {
            return;
        }
        if(this.transform.position.y < -3)
        {
            myHp = 0;
        }
        //���G���Ԃ̃J�E���g
        if(isInvincibility)
        {
            Color32 color = colorOrigin;
            if (countInvincibility > invincibilityTime)
            {
                isInvincibility = false;
                countInvincibility = 0;
                GetComponent<Renderer>().material.color = color;
                headObj.GetComponent<Renderer>().material.color = color;
            }
            countInvincibility++;
            if((float)(countInvincibility) % 6 == 0)
            {
                color = colorChange;
            }
            GetComponent<Renderer>().material.color = color;
            headObj.GetComponent<Renderer>().material.color = color;
        }
        /////////////////////////////////////////////////////
        ///�r�[��
        if (isBeamCount)
        {
            beamFreamCount++;
            if (beamFreamCount > beamFream)
            {
                beamFreamCount = 0;
                isBeamCount = false;
                isShotBeam = false ;
            }
            return;
        }

        if (isCharge)
        {
            if (beamGauge > 100.0f)
            {
                beamGauge = 100.0f;
                isShotBeam = true;
            }
            else
            {
                beamGauge += 0.5f;
            }
        }

      
        //////////////////////////////////////////////////

        coolTime++;
        if(coolTime > canCoolTime)
        {
            isShotNomal = true;
            isShotStrong = true;
        }
        if(coolTime > 20)
        {
            moveSpeed = tempSpeed;
        }

        //�v���C���[�̈ړ�
        playerRb.AddForce(this.transform.forward * inputMove.y * moveSpeed * Time.deltaTime, ForceMode.Impulse);


        //this.transform.Translate(inputMove.y * moveVec * Time.deltaTime);
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

        if (myHp <= 0)
        {
            isDead = true;
            Instantiate(deadExplosion, this.transform.position, Quaternion.identity);
            playerStock--;
        }

    }
 
    public void OnShotNomal(InputAction.CallbackContext context)
    {
        moveSpeed = 0;
        if (isShotNomal)
        {
            //�e�̔��˂���ꏊ���擾����
            Vector3 bulletPosition = shotPoint.transform.position;
            //
            GameObject newBullet = Instantiate(bulletNomal, bulletPosition, head.gameObject.transform.rotation);
            Vector3 dir = newBullet.transform.forward;
            newBullet.GetComponent<Rigidbody>().AddForce(dir * nomalBulletSpeed * Time.deltaTime, ForceMode.Impulse);
            coolTime = 0;
            isShotStrong = false;
            isShotNomal = false;
        }
    }
    public void OnShotStrong(InputAction.CallbackContext context)
    {
        moveSpeed = 0;
        if (isShotStrong)
        {
            //�e�̔��˂���ꏊ���擾����
            Vector3 bulletPosition = shotPoint.transform.position;
            //
            GameObject newBullet = Instantiate(bulletStrong, bulletPosition, head.gameObject.transform.rotation);
            Vector3 dir = newBullet.transform.forward;
            newBullet.GetComponent<Rigidbody>().AddForce(dir * strongBulletSpeed * Time.deltaTime, ForceMode.Impulse);
            coolTime = 0;
            isShotNomal = false;
            isShotStrong = false;
        }
    }

    public void OnShotBeam(InputAction.CallbackContext context)
    {
        if (context.started && isShotBeam) // �{�^�����������Ƃ�
        {
            isBeamCount = true;
            if (beamFreamCount > 60)
            {
                //�e�̔��˂���ꏊ���擾����
                Vector3 bulletPosition = shotPoint.transform.position;
                //
                GameObject newBullet = Instantiate(bulletBeam, bulletPosition, head.gameObject.transform.rotation);
                // Vector3 dir = newBullet.transform.forward;
                beamGauge = 0;

                isShotBeam = false;
                Destroy(newBullet, 1); //10�b��ɒe������
            }
          
        }
    }

    public void OnCharge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //�������u�Ԃ̏���
            isCharge = true;
        }
        if (context.canceled)
        {
            //�������u�Ԃ̏���
            isCharge = false;
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


    private void OnTriggerEnter(Collider other)
    {
        if (isInvincibility)
        {
            return;
        }
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName != playerIndex)
        {
            if (other.gameObject.tag == "Bullet")
            {
                myHp -= 5;
            }
            if (other.gameObject.tag == "StrongBullet")
            {
                myHp -= 30;
            }

        }
    }
    //�r�[���̑��i�q�b�g
    public void OnTriggerStay(Collider other)
    {
        if (isInvincibility)
        {
            return;
        }
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName != playerIndex)
        {
            if (other.gameObject.tag == "Beam")
            {
                myHp -= 2;
            }
        }
    }
}
