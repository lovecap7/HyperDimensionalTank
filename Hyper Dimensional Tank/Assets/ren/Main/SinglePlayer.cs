using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Transactions;
//using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
//using static UnityEditor.Experimental.GraphView.GraphView;
//using static UnityEditor.Timeline.TimelinePlaybackControls;
//using static UnityEngine.EventSystems.StandaloneInputModule;

public class SinglePlayer : MonoBehaviour
{
    [SerializeField] private string playerIndex;

    //スタートするまで動けない
    private StartCount startCount;
    [SerializeField] private GameObject startCountObj;

    //プレイヤーの動き
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

    //弾の動き
    //弾の発射場所
    [SerializeField] private GameObject shotPoint;

    //弾
    [SerializeField] private GameObject bulletNomal;
    [SerializeField] private GameObject bulletStrong;


    //弾の速さ
    private float nomalBulletSpeed = 600f;
    private float strongBulletSpeed = 300f;

    //ダメージ
    private int damegeNomal = 5;
    private int damegeStrong = 30;
    private int damegeBeam = 2;

    
   
    //爆発
    [SerializeField] private GameObject deadExplosion = null;


    //玉のクールタイム
    private int nomalCoolTime;
    private int canNomalCoolTime = 25;
    private int strongCoolTime;
    private int canStrongCoolTime = 75;
    private bool isShotNomal = true;
    private bool isShotStrong = true;
    //チャージエフェクト
    [SerializeField] private GameObject chargeEffect;
    //MAXの時のエフェクト
    [SerializeField] private GameObject maxEffect;

    //ビーム(必殺技)
    [SerializeField] private GameObject bulletBeam;
    [SerializeField] private GameObject beamCharge;
    private bool isShotBeam = false;
    private float chargeValue = 0.1f;
    public float beamGauge = 0;
    private bool isCharge = false;
    GameObject newBeam = null;
    //ビームの全体フレーム
    private int beamFream = 120;
    private float beamFreamCount = 0.0f;
    private bool isBeamCount = false;

    //バリア
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

    // Start is called before the first frame update
    void Start()
    {
        //最初の三秒間は動けない
        startCount = startCountObj.GetComponent<StartCount>();
        //エフェクトを非表示
        beamCharge.SetActive(false);
        chargeEffect.SetActive(false);
        maxEffect.SetActive(false);
        //バリアのクールタイムを0秒に
        burrierCoolTime = 0.0f;
        barrier.SetActive(false);
        //AddForceを使うために取得
        playerRb = this.transform.GetComponent<Rigidbody>();
        //頭を動かせるようにする
        head = transform.GetChild(0);
        //コントローラーで動かせるようにする
        playerControl = new PlayerControl();
        playerControl.Enable();
        //弾を打った時にスピードを0にするため一時的にmoveSpeedをtempにいれる
        tempSpeed = moveSpeed;
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

    }
    public void HeadRotationLeft(InputAction.CallbackContext context)
    {
       
        if (context.started) // ボタンを押したとき
        {
            isLeft = true;
        }
        else if (context.canceled) // ボタンを離したとき
        {
            isLeft = false;
        }
    }

    public void HeadRotationRight(InputAction.CallbackContext context)
    {
        if (context.started) // ボタンを押したとき
        {
            isRight = true;
        }
        else if (context.canceled) // ボタンを離したとき
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
        if(this.transform.position.y <= -5)
        {
            this.transform.position = new Vector3(0,5,0);
        }
      
        /////////////////////////////////////////////////////
        ///ビーム
        ///

        //ビームが消えるまで動けない
        if (newBeam != null)
        {
            Destroy(newBeam, 1); //弾を消す
            return;
        }

        //ビームのための間頭は動かせる
        if (isLeft)
        {
            //Quaternion.AngleAxis(度数法, 軸);
            head.rotation *= Quaternion.AngleAxis(-headRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (isRight)
        {
            //Quaternion.AngleAxis(度数法, 軸);
            head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        }

        //バリアのフレーム
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
        //ビーム発射フレームカウント開始
        if (isBeamCount)
        {

            beamGauge = 0;
            beamFreamCount++;
            if (beamFreamCount > 50.0f)
            {
                //プレイヤーの反動
                playerRb.AddForce(this.transform.forward * -200 * Time.deltaTime, ForceMode.Impulse);

                beamCharge.SetActive(false);
                maxEffect.SetActive(false);
                //弾の発射する場所を取得する
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

        //玉のクールタイム
        //クールタイムカウント
        //if (coolTime > 20)
        //{
        //    moveSpeed = tempSpeed;
        //}
        nomalCoolTime++;
        if (nomalCoolTime > canNomalCoolTime)
        {
            if (!isShotNomal)
            {
                //プレイヤーの反動
                playerRb.AddForce(this.transform.forward * -200 * Time.deltaTime, ForceMode.Impulse);
                //弾の発射する場所を取得する
                Vector3 bulletPosition = shotPoint.transform.position;
                //
                GameObject newBullet = Instantiate(bulletNomal, bulletPosition, head.gameObject.transform.rotation);
                Vector3 dir = newBullet.transform.forward;
                newBullet.GetComponent<Rigidbody>().AddForce(dir * nomalBulletSpeed * Time.deltaTime, ForceMode.Impulse);
                nomalCoolTime = 0;
            }
        }
        strongCoolTime++;
        if (strongCoolTime > canStrongCoolTime)
        {
            isShotStrong = true;
        }


        //isShotNomal = false;
        //isShotStrong = true;

        //チャージ中は球を打てなくしたい
        //ゲージチャージ
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



        //プレイヤーの移動
        playerRb.AddForce(this.transform.forward * inputMove.y * moveSpeed * Time.deltaTime, ForceMode.Impulse);
        //Quaternion.AngleAxis(度数法, 軸);
        this.transform.rotation *= Quaternion.AngleAxis(inputMove.x * bodyRotateSpeed * Time.deltaTime, Vector3.up);


    }

    public void OnShotNomal(InputAction.CallbackContext context)
    {
        
        if (startCount != null || isBarrier || isCharge)
        {
            return;
        }
        if (context.performed)
        {
            moveSpeed = 0;
            //押した瞬間の処理
            isShotNomal = false;
        }
        if (context.canceled)
        {
            moveSpeed = tempSpeed;
            //離した瞬間の処理
            isShotNomal = true;
        }
    }
    public void OnShotStrong(InputAction.CallbackContext context)
    {
      
        if (startCount != null || isBarrier || isCharge)
        {
            return;
        }
        if (context.started && isShotStrong) // ボタンを押したとき
        {
            //プレイヤーの反動
            playerRb.AddForce(this.transform.forward * -500 * Time.deltaTime, ForceMode.Impulse);
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(seSound);
            //弾の発射する場所を取得する
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
       
        if (startCount != null)
        {
            return;
        }
        if (context.performed && burrierCoolTime <= 0.0f && !isBeamCount)
        {
            //押した瞬間の処理
            barrier.SetActive(true);
            burrierCoolTime = 1800.0f;
            isBarrier = true;
        }
    }

    public void OnChargeAndBeam(InputAction.CallbackContext context)
    {
       
        if (startCount != null && !isBarrier)
        {
            return;
        }
        if (context.started && isShotBeam && !isBarrier) // ボタンを押したとき
        {
            beamCharge.SetActive(true);
            isBeamCount = true;
        }
        if (context.performed)
        {
            //押した瞬間の処理
            isCharge = true;
            audioSource.Play();

        }
        if (context.canceled)
        {
            //離した瞬間の処理
            isCharge = false;
            chargeEffect.SetActive(false);
            audioSource.Stop();
        }


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        // 入力値を保持しておく
        inputMove = context.ReadValue<Vector2>();

    }




   
   

    
}
