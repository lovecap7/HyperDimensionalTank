using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null; // Text�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        TextMeshProUGUI scoreText =scoreObject.GetComponent<TextMeshProUGUI>();
        // �e�L�X�g�̕\�������ւ���
        scoreText.text = "000000";
    }
}
