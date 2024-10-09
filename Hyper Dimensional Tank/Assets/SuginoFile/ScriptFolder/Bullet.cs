using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject explosion = null;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {


        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
