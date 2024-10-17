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

    int count = 0;

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
        count++;    //FixedUpdateのときは1秒が50フレームになる

        if(count > 500/*生成間隔*/)  // もし、カウントが生成する感覚を超えたら
        {
            count=0;    // カウントの初期化
            //RandPosx =Random.Range(RangeStart,RangeEnd);
            //RandPosz =Random.Range(RangeStart,RangeEnd);
            //Instantiate(MinBlock,new Vector3(RandPosx,1,RandPosz),Quaternion.identity);   // 出したいブロックを
            //RandPosx = Random.Range(RangeStart, RangeEnd);
            //RandPosz = Random.Range(RangeStart, RangeEnd);
            //Instantiate(MiddleBlock,new Vector3(RandPosx,1,RandPosz),Quaternion.identity);   // 出したいブロックを
            //RandPosx = Random.Range(RangeStart, RangeEnd);
            //RandPosz = Random.Range(RangeStart, RangeEnd);
            //Instantiate(StrongBlock,new Vector3(RandPosx,1,RandPosz),Quaternion.identity);   // 出したいブロックを

            do
            {
                RandPosx = Random.Range(RangeStart, RangeEnd);
                RandPosz = Random.Range(RangeStart, RangeEnd);
                SpawnPos = new Vector3(RandPosx, 1, RandPosz);
            } while (Vector3.Distance(SpawnPos, Player.transform.position) < 4);

            // ブロックの生成

            Instantiate(MiddleBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);
        }
    }
   
}
