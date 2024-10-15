using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayWall : MonoBehaviour
{
    private static int damage = 0;
    [SerializeField]
    private int HP;

    // 点数の量(一個壊すたびに一点増える)
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
        if (other.gameObject.tag == "Bullet")   // 弾に当たったらブロックのHPを減らして壊れたらスコアを追加
        {
            damage++;
            if (damage >= HP)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }

        }
        if (other.gameObject.tag == "StrongBullet")
        {
            damage += 2;
            if (damage >= HP)
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
            damage++;
            if (damage >= HP)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }
        }
    }
}
