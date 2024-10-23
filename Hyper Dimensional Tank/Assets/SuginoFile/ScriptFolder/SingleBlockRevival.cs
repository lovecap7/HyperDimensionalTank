using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBlockRevival : MonoBehaviour
{
    [SerializeField]GameObject MinBlock;
    [SerializeField]GameObject MiddleBlock;
    [SerializeField]GameObject StrongBlock;

    [SerializeField] GameObject Player;

    Vector3 SpawnPos;

    int minCount = 0;
    int middleCount = 0;
    int strongCount = 0;


    int RandPosx = 0;
    int RandPosz = 0;

    int RangeStart = -7;
    int RangeEnd = 8;

    
    

    GameObject Temp;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void FixedUpdate()
    {
        minCount++;    //FixedUpdate�̂Ƃ���1�b��50�t���[���ɂȂ�

        if (minCount > 100/*�����Ԋu*/)  // �����A�J�E���g���������銴�o�𒴂�����
        {
            minCount = 0;    // �J�E���g�̏�����
            //RandPosx =Random.Range(RangeStart,RangeEnd);
            //RandPosz =Random.Range(RangeStart,RangeEnd);
            //Instantiate(MinBlock,new Vector3(RandPosx,1,RandPosz),Quaternion.identity);   // �o�������u���b�N��
            //RandPosx = Random.Range(RangeStart, RangeEnd);
            //RandPosz = Random.Range(RangeStart, RangeEnd);
            //Instantiate(MiddleBlock,new Vector3(RandPosx,1,RandPosz),Quaternion.identity);   // �o�������u���b�N��
            //RandPosx = Random.Range(RangeStart, RangeEnd);
            //RandPosz = Random.Range(RangeStart, RangeEnd);
            //Instantiate(StrongBlock,new Vector3(RandPosx,1,RandPosz),Quaternion.identity);   // �o�������u���b�N��

            do
            {
                RandPosx = Random.Range(RangeStart, RangeEnd);
                RandPosz = Random.Range(RangeStart, RangeEnd);
                SpawnPos = new Vector3(RandPosx, 1, RandPosz);
            } while (Vector3.Distance(SpawnPos, Player.transform.position) < 4);
            // �u���b�N�̐���
            Instantiate(MinBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);

        }
       
        if (middleCount > 200/*�����Ԋu*/)  // �����A�J�E���g���������銴�o�𒴂�����
        {
            middleCount = 0;    // �J�E���g�̏�����

            do
            {
                RandPosx = Random.Range(RangeStart, RangeEnd);
                RandPosz = Random.Range(RangeStart, RangeEnd);
                SpawnPos = new Vector3(RandPosx, 1, RandPosz);
            } while (Vector3.Distance(SpawnPos, Player.transform.position) < 4);

            // �u���b�N�̐���
            Instantiate(MiddleBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);
        }
        if (strongCount > 500/*�����Ԋu*/)  // �����A�J�E���g���������銴�o�𒴂�����
        {
            strongCount = 0;    // �J�E���g�̏�����

            do
            {
                RandPosx = Random.Range(RangeStart, RangeEnd);
                RandPosz = Random.Range(RangeStart, RangeEnd);
                SpawnPos = new Vector3(RandPosx, 1, RandPosz);
            } while (Vector3.Distance(SpawnPos, Player.transform.position) < 4);
            // �u���b�N�̐���
            Instantiate(StrongBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);

        }
    }
   
}
