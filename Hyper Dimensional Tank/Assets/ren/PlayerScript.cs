using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

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
    private float shotCoolTime = 0f;
    private bool isShot = true;
    // Start is called before the first frame update
    void Start()
    {
        head = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

       

        if(isShot)
        {
            shotCoolTime = 0.0f;
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
            if(shotCoolTime > 60.0f)
            {
                isShot = true;
            }
            shotCoolTime++;
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
}
