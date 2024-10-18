using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Unityのシーンのマネジメント役割
public class SingleSceneManager2 : MonoBehaviour
{
    public void BackHome_bottun()
    {
        SceneManager.LoadScene("ModeSelectScene"); // SinglePlaySceneを呼び出す
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
