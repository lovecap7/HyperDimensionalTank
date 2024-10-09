using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minController : MonoBehaviour
{
    int count = 0;
    [SerializeField]
    GameObject explosion = null;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            count++;
            if(count > 2) 
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
