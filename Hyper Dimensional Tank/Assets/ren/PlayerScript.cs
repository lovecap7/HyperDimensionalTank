using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerScript : MonoBehaviour
{
    //�v���C���[�̓���
    private float bodyRotateSpeed = 50f;
    private float headRotateSpeed = 50f;
    Vector3 moveSpeed = new Vector3(0, 0, 1f);
    Transform head;

    //�e�̓���
    //�e�̔��ˏꏊ
    public GameObject shotPoint;

    //�e
    public GameObject bullet;

    //�e�̑���
    private float bulletSpeed = 100f;

    //�N�[���^�C��
    private int countCoolTime = 0;
    private int shotCoolTime = 60;
    private bool isShot = true;

    //�̗�
    private int myHp = 100;
    private bool isDead = false;
    private int respawnTime = 180;

    //�c�@
    private int playerStock = 2;
    // Start is called before the first frame update
    void Start()
    {
        head = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStock < 0)
        {
            Debug.Log("���Ȃ��̕���");
            return;
        }
        if (isDead)
        {
            respawnTime--;
            if (respawnTime < 0)//����
            {
                isDead = false;
                respawnTime = 180;
                myHp = 100;
                this.gameObject.transform.position = new Vector3(0, 10, 0);
            }
            return;
        }
        
        PlayerMove();

       

        if(isShot)
        {
            countCoolTime = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //�e�̔��˂���ꏊ���擾����
                Vector3 bulletPosition = shotPoint.transform.position;
                //
                GameObject newBullet = Instantiate(bullet, bulletPosition, head.gameObject.transform.rotation);
                Vector3 dir = newBullet.transform.forward;
                newBullet.GetComponent<Rigidbody>().AddForce(dir * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
                isShot = false;
            }
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

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.Translate(moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.Translate(-moveSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.rotation *= Quaternion.AngleAxis(bodyRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.rotation *= Quaternion.AngleAxis(-bodyRotateSpeed * Time.deltaTime, Vector3.up);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(-headRotateSpeed * Time.deltaTime, Vector3.up);
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            myHp -= 100;
            Debug.Log(myHp);
        }

        if(myHp <= 0)
        {
            playerStock--;
            isDead = true;
        }
    }
}
