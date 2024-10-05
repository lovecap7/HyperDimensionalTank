using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null; // Text�I�u�W�F�N�g

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //// �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        //TextMeshProUGUI scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        //// �e�L�X�g�̕\�������ւ���
        //scoreText.text = "Score00000" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �X�R�A�𑝉������郁�\�b�h
    // �O������A�N�Z�X���邩��public�Œ�`������
    public void AddScore(int amount)
    {
        score += amount;
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        TextMeshProUGUI scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score" + score;

    }
}
