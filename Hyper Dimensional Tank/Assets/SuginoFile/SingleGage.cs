using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleGage : MonoBehaviour
{
    private GameObject playerObj1P;
    private SinglePlayer playerScript1P;
    //beamUI
    [SerializeField] private Slider beamBar1P;
   
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        playerObj1P = GameObject.Find("Player1");
        playerScript1P = playerObj1P.GetComponent<SinglePlayer>();
        //ビームのゲージを0に
        beamBar1P.value = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        //ビームの描画
        beamBar1P.value = (float)(playerScript1P.beamGauge) / 100.0f;
    }
}
