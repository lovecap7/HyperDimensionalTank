using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3.0f;�@�@// ������
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �u���b�N�̈ړ�
        transform.position = new Vector3(Mathf.Sin(Time.time) * MoveSpeed, 0, 0);
    }
}
