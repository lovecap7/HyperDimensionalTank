using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Unity�̃V�[���̃}�l�W�����g����
public class SingleSceneManager2 : MonoBehaviour
{
    public void BackHome_bottun()
    {
        SceneManager.LoadScene("ModeSelectScene"); // SinglePlayScene���Ăяo��
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
