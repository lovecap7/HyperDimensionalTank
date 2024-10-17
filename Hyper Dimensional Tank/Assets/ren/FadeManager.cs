using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private float fadeSpeed = 0.001f;
    float alfa; //“§–¾“x
    float red, green, blue;//RGB
    // Start is called before the first frame update
    void Start()
    {
        alfa = 0.0f;
        red = this.gameObject.GetComponent<Image>().color.r;
        green = this.gameObject.GetComponent<Image>().color.g;
        blue = this.gameObject.GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Image>().color = new Color(red, green, blue,alfa);
        alfa += fadeSpeed;
        if (alfa >= 254.0f)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
