using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayWall : MonoBehaviour
{
    private static int count = 0;
    [SerializeField]
    private int sCount;

    public static int scoreValue;
    private ScoreManager ScoreManager;

    [SerializeField]
    private GameObject explosion = null;

    

    void Start()
    {
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    public static int getScore()
    {
        return scoreValue;
    }

private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            count++;
            if (count >= sCount)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }

        }
        if (other.gameObject.tag == "StrongBullet")
        {
            count += 2;
            if (count >= sCount)
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
            if (count >= sCount)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScoreManager.AddScore(scoreValue);
            }

        }
    }
}
