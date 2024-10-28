using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x >=30 ||
            this.transform.position.x<=-30)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.z >= 30 ||
            this.transform.position.z <= -30)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag =="Cube")
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
        }
    }
}
