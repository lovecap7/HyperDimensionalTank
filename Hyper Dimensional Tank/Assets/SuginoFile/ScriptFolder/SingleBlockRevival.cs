using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBlock : MonoBehaviour
{
    GameObject MinBlock;
    int count;
     
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;    //FixedUpdate�̂Ƃ���1�b��50�t���[���ɂȂ�
        if (count > 500/*�����Ԋu*/)   //�����A�J�E���g����������Ԋu�𒴂�����
        {
            count = 0;  // �J�E���g�̏�����
            Instantiate(MinBlock, new Vector3(5, 0, 5), Quaternion.identity);   // �o�������u���b�N���o���������W�ɕ\������
        }
    }
}
