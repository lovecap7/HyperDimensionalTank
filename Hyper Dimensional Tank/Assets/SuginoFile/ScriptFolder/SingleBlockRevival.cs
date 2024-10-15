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
        count++;    //FixedUpdateのときは1秒が50フレームになる
        if (count > 500/*生成間隔*/)   //もし、カウントが生成する間隔を超えたら
        {
            count = 0;  // カウントの初期化
            Instantiate(MinBlock, new Vector3(5, 0, 5), Quaternion.identity);   // 出したいブロックを出したい座標に表示する
        }
    }
}
