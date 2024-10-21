using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public bool isFadeIn = false;
    private float fadeSpeed =0.02f;
    float alfa; //“§–¾“x
    float red, green, blue;//RGB
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        alfa = 1.0f;
        red = this.gameObject.GetComponent<Image>().color.r;
        green = this.gameObject.GetComponent<Image>().color.g;
        blue = this.gameObject.GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFadeIn)
        {
            sceneName = PlayerPrefs.GetString("SCENENAME", "TitleScene");
            this.gameObject.GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += fadeSpeed;
            Debug.Log(alfa);
            if (alfa >= 1.2f)
            {
               
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa -= fadeSpeed;
            if (alfa <= 0.0f)
            {
                alfa = 0.0f;
            }
        }
        
    }
}
