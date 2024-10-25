using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : MonoBehaviour
{
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
}
