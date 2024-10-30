using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript_ren : MonoBehaviour
{
    [SerializeField]
    private int hp = 0;
    
    //private int maxHp;

    [SerializeField]
    private GameObject explosion = null;
    [SerializeField]
    private GameObject itemBox = null;
    private int randomIndex = 0;
    private int randomNum;
    void Start()
    {
        randomNum = Random.Range(0, 5);@// ¦ 0`4‚Ì”ÍˆÍ‚Åƒ‰ƒ“ƒ_ƒ€‚È®”’l‚ª•Ô‚é
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Bullet")
    //    {
    //        hp--;
    //    }
    //    if (collision.gameObject.tag == "StrongBullet")
    //    {
    //        hp -= 2;
    //    }
    //    if (hp <= 0)
    //    {
    //        Instantiate(explosion, transform.position, Quaternion.identity);
    //        Destroy(gameObject);
    //    }
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Beam")
    //    {
    //        hp--;
    //        if (hp <= 0)
    //        {
    //            Instantiate(explosion, transform.position, Quaternion.identity);
    //            Destroy(gameObject);
    //        }

    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
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
            if (randomIndex == randomNum)
            {
                Instantiate(itemBox, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
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
                if (randomIndex == randomNum)
                {
                    Instantiate(itemBox, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }

        }
    }




}
