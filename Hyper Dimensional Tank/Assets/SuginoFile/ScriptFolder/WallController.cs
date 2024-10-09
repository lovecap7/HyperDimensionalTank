using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private int count = 0;
    [SerializeField]
    private int sCount;

    [SerializeField]
    private GameObject explosion = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            count++;
            if (count >= sCount)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        if (other.gameObject.tag == "StrongBullet")
        {
            count += 2;
            if (count >= sCount)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
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
            }

        }
    }

}
