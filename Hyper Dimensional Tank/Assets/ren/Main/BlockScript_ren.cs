using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript_ren : MonoBehaviour
{
    private int count = 0;
    [SerializeField]
    private int sCount;

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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            count++;
        }
        if (other.gameObject.tag == "StrongBullet")
        {
            count += 2;
        }
        if (count >= sCount)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            if(randomIndex == randomNum)
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
            count++;
            if (count >= sCount)
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
