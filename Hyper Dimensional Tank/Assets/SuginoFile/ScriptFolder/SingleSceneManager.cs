using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Unity�̃V�[���̃}�l�W�����g����

public class SingleSceneManager : MonoBehaviour
{
    public void retry_bottun()
    {
        SceneManager.LoadScene("SinglePlayScene"); // SinglePlayScene���Ăяo��
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
