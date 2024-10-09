using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCount : MonoBehaviour
{
    TextMeshPro textMeshPro;
    int count = 180;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        count--;
        textMeshPro.text = ((count / 60) + 1).ToString("d1");
    }
}
