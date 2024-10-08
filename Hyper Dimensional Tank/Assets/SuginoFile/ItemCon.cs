using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCom : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.name == "Player2")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpeedUp()
    {
        speed = 0.1f;
        yield return new WaitForSeconds(3.0f);
        speed = 0.01f;
    }
}
