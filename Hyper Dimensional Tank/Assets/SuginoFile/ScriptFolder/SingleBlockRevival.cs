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
        minCount++;    //FixedUpdateのときは1秒が50フレームになる

        if (minCount > 100/*生成間隔*/)  // もし、カウントが生成する感覚を超えたら
        {
            minCount = 0;    // カウントの初期化
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
            Instantiate(MinBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);

        }
       
        if (middleCount > 200/*生成間隔*/)  // もし、カウントが生成する感覚を超えたら
        {
            middleCount = 0;    // カウントの初期化

            do
            {
                RandPosx = Random.Range(RangeStart, RangeEnd);
                RandPosz = Random.Range(RangeStart, RangeEnd);
                SpawnPos = new Vector3(RandPosx, 1, RandPosz);
            } while (Vector3.Distance(SpawnPos, Player.transform.position) < 4);

            // ブロックの生成
            Instantiate(MiddleBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);
        }
        if (strongCount > 500/*生成間隔*/)  // もし、カウントが生成する感覚を超えたら
        {
            strongCount = 0;    // カウントの初期化

            do
            {
                RandPosx = Random.Range(RangeStart, RangeEnd);
                RandPosz = Random.Range(RangeStart, RangeEnd);
                SpawnPos = new Vector3(RandPosx, 1, RandPosz);
            } while (Vector3.Distance(SpawnPos, Player.transform.position) < 4);
            // ブロックの生成
            Instantiate(StrongBlock, new Vector3(RandPosx, 1, RandPosz), Quaternion.identity);

        }
    }
   
}
