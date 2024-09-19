using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float bodyRotateSpeed = 50f;
    private float headRotateSpeed = 50f;
    Vector3 moveSpeed = new Vector3(0, 0, 1f);
    Transform head;
    // Start is called before the first frame update
    void Start()
    {
        head = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.Translate(moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.Translate(-moveSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.rotation *= Quaternion.AngleAxis(bodyRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            this.transform.rotation *= Quaternion.AngleAxis(-bodyRotateSpeed * Time.deltaTime, Vector3.up);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(headRotateSpeed * Time.deltaTime, Vector3.up);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Quaternion.AngleAxis(�x���@, ��);
            head.rotation *= Quaternion.AngleAxis(-headRotateSpeed * Time.deltaTime, Vector3.up);
        }


    }
}
