using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    public Transform target;

    public float rotateSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround
        (target.position,
        Vector3.up,
        rotateSpeed * Time.deltaTime);
    }
}
