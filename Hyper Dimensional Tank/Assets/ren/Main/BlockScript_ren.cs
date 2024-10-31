using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript_ren : MonoBehaviour
{
    [SerializeField]
    private int hp = 0;
    
    Color myColor;
    //private int maxHp;

    [SerializeField]
    private GameObject explosion = null;
    [SerializeField]
    private GameObject itemBox = null;
    private int randomIndex = 0;
    private int randomNum;
    void Start()
    {
        myColor = this.gameObject.GetComponent<Renderer>().material.color;
        randomNum = Random.Range(0, 4);Å@// Å¶ 0Å`3ÇÃîÕàÕÇ≈ÉâÉìÉ_ÉÄÇ»êÆêîílÇ™ï‘ÇÈ
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
            GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 0);
            Invoke("back", 0.2f);
        }
        if (other.gameObject.tag == "StrongBullet")
        {
            hp -= 3;
            GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 0);
            Invoke("back", 0.2f);
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
            GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 0);
            Invoke("back", 0.2f);
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
    void back()
    {
        this.gameObject.transform.GetComponent<Renderer>().material.color = myColor;
    }
}
