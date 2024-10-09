using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCount : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
   // public bool isGameStart = false;
    int count = 180;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        count--;
        textMeshPro.text = ((count / 60) + 1).ToString("d1");
        if (count < 0)
        {
            textMeshPro.fontSize = 350;
            textMeshPro.text = "START";
        }
        if (count < -60)
        {
            //isGameStart = true;
            Destroy(this.gameObject);
        }
    }
}
