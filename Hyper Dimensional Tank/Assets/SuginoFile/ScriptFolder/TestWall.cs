using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWall : MonoBehaviour
{
    private int count = 0;
    [SerializeField]
    private int sCount;

    [SerializeField]
    private GameObject explosion = null;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            count++;
            if (count >= sCount)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.tag == "StrongBullet")
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





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
