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


public class SinglePlayer : MonoBehaviour
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

  

   

    //����
    [SerializeField] private GameObject deadExplosion = null;


    //�ʂ̃N�[���^�C��
    private int coolTime;
    private int canCoolTime = 60;
    private bool isShotNomal = true;
    private bool isShotStrong = true;
    //�`���[�W�G�t�F�N�g
    [SerializeField] private GameObject chargeEffect;
    //MAX�̎��̃G�t�F�N�g
    [SerializeField] private GameObject maxEffect;

    //�r�[��(�K�E�Z)
    [SerializeField] private GameObject bulletBeam;
    [SerializeField] private GameObject beamCharge;
    private bool isShotBeam = false;
    private float chargeValue = 0.2f;
    public float beamGauge = 0;
    private bool isCharge = false;
    GameObject newBeam = null;
    //�r�[���̑S�̃t���[��
    private int beamFream = 120;
    private int beamFreamCount = 0;
    private bool isBeamCount = false;

    //InputSystem
    private PlayerControl playerControl;

    //SE
    public AudioClip[] seSound = new AudioClip[2];
    //public AudioClip beamSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
      
        beamCharge.SetActive(false);
        chargeEffect.SetActive(false);
        maxEffect.SetActive(false);
        playerRb = this.transform.GetComponent<Rigidbody>();
        //moveVec = new Vector3(0,0,moveSpeed);
        head = transform.GetChild(0);
        playerControl = new PlayerControl();
        playerControl.Enable();
        tempSpeed = moveSpeed;
        //Component���擾
        audioSource = GetComponent<AudioSource>();
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
    // Update is called once per frame
    void Update()
    {
      
        /////////////////////////////////////////////////////
        ///�r�[��
        ///

        //�r�[����������܂œ����Ȃ�
        if (newBeam != null)
        {
            Destroy(newBeam, 1); //�e������
            return;
        }
        //�r�[���̂��߂̊ԓ��͓�������
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
        //�r�[�����˃t���[���J�E���g�J�n
        if (isBeamCount)
        {

            beamGauge = 0;
            beamFreamCount++;
            if (beamFreamCount > 60)
            {
                beamCharge.SetActive(false);
                maxEffect.SetActive(false);
                //�e�̔��˂���ꏊ���擾����
                Vector3 bulletPosition = shotPoint.transform.position;
                //
                newBeam = Instantiate(bulletBeam, bulletPosition, head.gameObject.transform.rotation);


                beamFreamCount = 0;
                isBeamCount = false;
                isShotBeam = false;
            }
            return;
        }



        //////////////////////////////////////////////////

        //�ʂ̃N�[���^�C��
        //�N�[���^�C���J�E���g
        coolTime++;
        if (coolTime > canCoolTime)
        {
            isShotNomal = true;
            isShotStrong = true;
        }
        if (coolTime > 20)
        {
            moveSpeed = tempSpeed;
        }
        //�`���[�W���͋���łĂȂ�������
        //�Q�[�W�`���[�W
        if (isCharge)
        {
            if (beamGauge >= 100)
            {
                //isCharge = false;
                beamGauge = 100.0f;
                isShotBeam = true;
                chargeEffect.SetActive(false);
                maxEffect.SetActive(true);
                audioSource.Stop();
            }
            else
            {
                beamGauge += chargeValue;
                chargeEffect.SetActive(true);
            }
            isShotNomal = false;
            isShotStrong = false;
            return;
        }

        //�v���C���[�̈ړ�
        playerRb.AddForce(this.transform.forward * inputMove.y * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        //Quaternion.AngleAxis(�x���@, ��);
        this.transform.rotation *= Quaternion.AngleAxis(inputMove.x * bodyRotateSpeed * Time.deltaTime, Vector3.up);
    }

    public void OnShotNomal(InputAction.CallbackContext context)
    {
       
        moveSpeed = 0;
        if (isShotNomal)
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(seSound[0]);
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
            //��(sound1)��炷
            audioSource.PlayOneShot(seSound[0]);
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
            //��(sound1)��炷
            audioSource.PlayOneShot(seSound[1]);
            beamCharge.SetActive(true);
            isBeamCount = true;
        }
    }

    public void OnCharge(InputAction.CallbackContext context)
    {
      
        if (context.performed)
        {
            //�������u�Ԃ̏���
            isCharge = true;
            audioSource.Play();

        }
        if (context.canceled)
        {
            //�������u�Ԃ̏���
            isCharge = false;
            chargeEffect.SetActive(false);
            audioSource.Stop();
        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // ���͒l��ێ����Ă���
        inputMove = context.ReadValue<Vector2>();

    }




    
}


