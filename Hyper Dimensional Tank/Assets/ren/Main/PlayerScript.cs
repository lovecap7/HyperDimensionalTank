using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Transactions;
//using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.EventSystems.StandaloneInputModule;
//using static UnityEditor.Experimental.GraphView.GraphView;
//using static UnityEditor.Timeline.TimelinePlaybackControls;
//using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private string playerIndex;

    //�X�^�[�g����܂œ����Ȃ�
    private StartCount startCount;
    [SerializeField] private GameObject startCountObj;

    //�v���C���[�̓���
    private float moveSpeed = 12f;
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
    private float strongBulletSpeed = 300f;

    //�_���[�W
    private int damegeNomal = 5;
    private int damegeStrong = 30;
    private int damegeBeam = 2;
    //�ʂ̃N�[���^�C��
    private int nomalCoolTime;
    private int canNomalCoolTime = 25;
    private int strongCoolTime;
    private int canStrongCoolTime = 75;
    private bool isShotNomal = true;
    private bool isShotStrong = true;

    //�̗� public�ł悢
    public float myHp = 100;
    public bool isDead = false;
    public int playerStock = 2;
    //�c�@����񂾂����炷
    bool oneAction = false;


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


  
    //�`���[�W�G�t�F�N�g
    [SerializeField] private GameObject chargeEffect;
    //MAX�̎��̃G�t�F�N�g
    [SerializeField] private GameObject maxEffect;

    //�r�[��(�K�E�Z)
    [SerializeField] private GameObject bulletBeam;
    [SerializeField] private GameObject beamCharge;
    private bool isShotBeam = false;
    private float chargeValue = 0.1f;
    public float beamGauge = 0;
    private bool isCharge = false;
    GameObject newBeam = null;  
    //�r�[���̑S�̃t���[��
    private int beamFream = 120;
    private float beamFreamCount = 0.0f;
    private bool isBeamCount = false;

    //�o���A
    [SerializeField] private GameObject barrier;
    private bool isBarrier = false;
    private float cutRate = 0.5f;
    private float burrierFreme = 200.0f;
    public float burrierCoolTime = 1800.0f;
    //InputSystem
    private PlayerControl playerControl;

    //SE
    public AudioClip seSound;
    //public AudioClip beamSound;
    private AudioSource audioSource;

    // ����
    [SerializeField] private GameObject buffSpeedUp;
    [SerializeField] private GameObject buffFastShotUp;
    [SerializeField] private GameObject buffGageUp;
    public bool isBuffSp = false;
    public bool isBuffFs = false;
    public bool isBuffG = false;







    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��̎O�b�Ԃ͓����Ȃ�
        startCount = startCountObj.GetComponent<StartCount>();
        //�G�t�F�N�g���\��
        beamCharge.SetActive(false);
        chargeEffect.SetActive(false);
        maxEffect.SetActive(false);
        //�o���A�̃N�[���^�C����0�b��
        burrierCoolTime = 0.0f;
        barrier.SetActive(false);
        //AddForce���g�����߂Ɏ擾
        playerRb = this.transform.GetComponent<Rigidbody>();
        //���𓮂�����悤�ɂ���
        head = transform.GetChild(0);
        //�R���g���[���[�œ�������悤�ɂ���
        playerControl = new PlayerControl();
        playerControl.Enable();
        //�e��ł������ɃX�s�[�h��0�ɂ��邽�߈ꎞ�I��moveSpeed��temp�ɂ����
        tempSpeed = moveSpeed;
        //Component���擾
        audioSource = GetComponent<AudioSource>();

        //�o�t
        buffSpeedUp.SetActive(false);
        buffFastShotUp.SetActive(false);
        buffGageUp.SetActive(false);

    }
    public void HeadRotationLeft(InputAction.CallbackContext context)
    {
        if (isDead)
        {
            return;
        }
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
        if (isDead)
        {
            return;
        }
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
    void FixedUpdate()
    {
        if (startCount != null)
        {
            return;
        }

        Dead();

        if (isDead)
        {
            return;
        }
        else
        {
            oneAction = false;
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

        //�o���A�̃t���[��
        if (burrierCoolTime <= 0.0f)
        {
            burrierCoolTime = 0;
        }
        else
        {
            burrierCoolTime--;
        }
        
        if (isBarrier)
        {
            burrierFreme--;
            if (burrierFreme < 0)
            {
                burrierFreme = 200.0f;
                isBarrier = false;
                barrier.SetActive(false);
            }
        }
        //�r�[�����˃t���[���J�E���g�J�n
        if (isBeamCount)
        {
           
            beamGauge = 0;
            beamFreamCount++;
            if (beamFreamCount > 50.0f)
            {
                //�v���C���[�̔���
                playerRb.AddForce(head.gameObject.transform.forward * -200 * Time.deltaTime, ForceMode.Impulse);

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
        //if (coolTime > 20)
        //{
        //    moveSpeed = tempSpeed;
        //}
        nomalCoolTime++;
        if (nomalCoolTime > canNomalCoolTime)
        {
            if (!isShotNomal && !isBarrier)
            {
                //�v���C���[�̔���
                playerRb.AddForce(head.gameObject.transform.forward * -100 * Time.deltaTime, ForceMode.Impulse);
                //�e�̔��˂���ꏊ���擾����
                Vector3 bulletPosition = shotPoint.transform.position;
                //
                GameObject newBullet = Instantiate(bulletNomal, bulletPosition, head.gameObject.transform.rotation);
                Vector3 dir = newBullet.transform.forward;
                newBullet.GetComponent<Rigidbody>().AddForce(dir * nomalBulletSpeed * Time.deltaTime, ForceMode.Impulse);
                nomalCoolTime = 0;
            }
        }
        strongCoolTime++;
        if(strongCoolTime > canStrongCoolTime)
        {
            isShotStrong = true;
        }


        //isShotNomal = false;
        //isShotStrong = true;

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
            return;
        }


        //�v���C���[�̈ړ�
        playerRb.AddForce(this.transform.forward * inputMove.y * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        //Quaternion.AngleAxis(�x���@, ��);
        this.transform.rotation *= Quaternion.AngleAxis(inputMove.x * bodyRotateSpeed * Time.deltaTime, Vector3.up);
    }
 
    public void OnShotNomal(InputAction.CallbackContext context)
    {
        if (isDead)
        {
            return;
        }
        if (startCount != null || isBarrier || isCharge || !isShotStrong)
        {
            return;
        }
        if (context.performed)
        {
            moveSpeed = 0;
            //�������u�Ԃ̏���
            isShotNomal = false;
        }
        if (context.canceled)
        {
            moveSpeed = tempSpeed;
            //�������u�Ԃ̏���
            isShotNomal = true;
        }
    }
    public void OnShotStrong(InputAction.CallbackContext context)
    {
        if (isDead)
        {
            return;
        }
        if (startCount != null || isBarrier || isCharge || !isShotNomal)
        {
            return;
        }
        if (context.started && isShotStrong) // �{�^�����������Ƃ�
        {
            //�v���C���[�̔���
            playerRb.AddForce(head.gameObject.transform.forward * -250 * Time.deltaTime, ForceMode.Impulse);
            //��(sound1)��炷
            audioSource.PlayOneShot(seSound);
            //�e�̔��˂���ꏊ���擾����
            Vector3 bulletPosition = shotPoint.transform.position;
            //
            GameObject newBullet = Instantiate(bulletStrong, bulletPosition, head.gameObject.transform.rotation);
            Vector3 dir = newBullet.transform.forward;
            newBullet.GetComponent<Rigidbody>().AddForce(dir * strongBulletSpeed * Time.deltaTime, ForceMode.Impulse);
            strongCoolTime = 0;
            isShotStrong = false;
        }
        
    }

    public void OnShotBarrier(InputAction.CallbackContext context)
    {
        if (isDead)
        {
            return;
        }
        if (startCount != null)
        {
            return;
        }
        if (context.performed && burrierCoolTime <= 0.0f && !isBeamCount)
        {
            //�������u�Ԃ̏���
            barrier.SetActive(true);
            burrierCoolTime = 1800.0f;
            isBarrier = true;
        }
    }

    public void OnChargeAndBeam(InputAction.CallbackContext context)
    {
        //
        if (isDead)
        {
            return;
        }
        if (startCount != null)
        {
            return;
        }
        if (context.started && isShotBeam && !isBarrier) // �{�^�����������Ƃ�
        {
            beamCharge.SetActive(true);
            isBeamCount = true;
        }
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
        if (isDead)
        {
            return;
        }
        // ���͒l��ێ����Ă���
        inputMove = context.ReadValue<Vector2>();
     
    }

   
    
    // �����蔻��
    private void OnTriggerEnter(Collider other)
    {
        if (isDead)
        {
            return;
        }
        if (isInvincibility)
        {
            return;
        }
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName != playerIndex)
        {
            float tempCut = 1.0f;
            if (isBarrier)
            {
                tempCut = 0.0f;
            }
            if (other.gameObject.tag == "Bullet")
            {
                myHp -= damegeNomal * tempCut;
            }
            if (other.gameObject.tag == "StrongBullet")
            {
                myHp -= damegeStrong * tempCut;
            }

        }
        UseItem(other.gameObject.tag);
    }
   
    
    //�r�[���̑��i�q�b�g
    public void OnTriggerStay(Collider other)
    {
        if (isDead)
        {
            return;
        }
        if (isInvincibility)
        {
            return;
        }
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if (layerName != playerIndex)
        {

            float tempCut = 1.0f;
            if (isBarrier)
            {
                tempCut = cutRate;
            }
            if (other.gameObject.tag == "Beam")
            {
                myHp -= damegeBeam * tempCut;
            }
        }
    }

    private void Dead()
    {
        if (myHp <= 0)
        {
            if (!oneAction)
            {
                isDead = true;
                //���͂����ׂă��Z�b�g
                inputMove = new Vector2(0, 0); moveSpeed = tempSpeed;
                isShotNomal = true;
                isCharge = false; 
                chargeEffect.SetActive(false);
                audioSource.Stop();
                beamCharge.SetActive(false);
                maxEffect.SetActive(false);
                beamFreamCount = 0;
                isBeamCount = false;
                isShotBeam = false;
                chargeValue += 0.1f; 
                /////////////////////////
                Instantiate(deadExplosion, this.transform.position, Quaternion.identity);
                playerStock--;
                oneAction = true;
            }
        }
    }
    void UseItem(string tagName)
    {
        Debug.Log("ItemSpeed");
        if (tagName == "ItemSpeed")
        {
            buffSpeedUp.SetActive(true);
            moveSpeed = 24.0f;
            isBuffSp =true;
            Invoke("ItemSpeedFinish", 7.0f);
        }
        if(tagName == "ItemFastShot")
        {
            buffFastShotUp.SetActive(true);
            canNomalCoolTime = 10;
            canStrongCoolTime = 30;
            isBuffFs = true;
            Invoke("ItemFastShotFinish", 5.0f);
        }
        if (tagName == "ItemGage")
        {
            buffGageUp.SetActive(true);
            beamGauge += 30.0f;
            isBuffG = true;
            Invoke("ItemGageFinish", 1.0f);
        }
    }
    void ItemSpeedFinish()
    {
        buffSpeedUp.SetActive(false);
        moveSpeed = tempSpeed;
        isBuffSp = false;
    }
    void ItemFastShotFinish()
    {
        buffFastShotUp.SetActive(false);
        canNomalCoolTime = 25;
        canStrongCoolTime = 75;
        isBuffFs = false;
    }
    void ItemGageFinish()
    {
        buffGageUp.SetActive(false);
        isBuffG = false;
    }

}
