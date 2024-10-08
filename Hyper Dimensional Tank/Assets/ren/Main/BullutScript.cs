using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullutScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject explosion;
    

    private void OnTriggerEnter(Collider other)
    {
        string otherLayerName = LayerMask.LayerToName(other.gameObject.layer);
        string myLayerName = LayerMask.LayerToName(this.gameObject.layer);
        if (otherLayerName != myLayerName)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
