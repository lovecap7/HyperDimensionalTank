using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayWall : MonoBehaviour
{
    //private static int count = 0;
    [SerializeField]
    private int hp;

    // �_���̗�(��󂷂��тɈ�_������)
    [SerializeField]
    private int scoreValue = 1;
    private ScoreManager ScoreManager;

    [SerializeField]
    private GameObject explosion = null;

    

    void Start()
    {
      
    }
    private void OnDestroy()
    {
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ScoreManager.AddScore(scoreValue);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bullet")   // �e�ɓ���������u���b�N��HP�����炵�ĉ�ꂽ��X�R�A��ǉ�
        {
            hp--;
        }
        if (other.gameObject.tag == "StrongBullet")
        {
            hp -= 2;
        }
        if (hp <= 0)
        {
            OnDestroy();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            hp--;
            if (hp <= 0)
            {
                OnDestroy();
            }
        }
    }

   
}
