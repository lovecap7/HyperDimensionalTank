using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayWall : MonoBehaviour
{
    private static int count = 0;
    [SerializeField]
    private int HP;

    // �_���̗�(��󂷂��тɈ�_������)
    [SerializeField]
    private int scoreValue = 1;
    private ScoreManager ScoreManager;

    [SerializeField]
    private GameObject explosion = null;

    

    void Start()
    {
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")   // �e�ɓ���������u���b�N��HP�����炵�ĉ�ꂽ��X�R�A��ǉ�
        {
            HP--;
            if(HP <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }

        }
        if (other.gameObject.tag == "StrongBullet")
        {
            HP -= 2;
            if(HP <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            count++;
            if (count >= HP)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }
        }
    }
}
