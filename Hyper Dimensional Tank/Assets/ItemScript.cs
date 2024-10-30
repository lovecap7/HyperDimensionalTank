using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private int hp = 5;

    [SerializeField]
    private GameObject explosion = null;
    private int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 3);�@// �� 0�`2�͈̔͂Ń����_���Ȑ����l���Ԃ�
        if(randomNum == 0)
        {
            this.gameObject.tag = "ItemSpeed";
        }
        else if (randomNum == 1)
        {
            this.gameObject.tag = "ItemFastShot";
        }
        if (randomNum == 2)
        {
            this.gameObject.tag = "ItemGage";
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            hp--;
        }
        if (other.gameObject.tag == "StrongBullet")
        {
            hp -= 3;
        }
        if (hp <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            hp--;
            if (hp <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }


}
