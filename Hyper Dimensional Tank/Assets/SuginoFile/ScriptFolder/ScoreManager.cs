using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int totalScore = 0;

    [SerializeField]TextMeshProUGUI scoreText = null;

    // Start is called before the first frame update
    void Start()
    {
        //// �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        //TextMeshProUGUI scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        //// �e�L�X�g�̕\�������ւ���
        //scoreText.text = "Score00000" + score;
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
         scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", totalScore);
        PlayerPrefs.Save();
    }

    // �X�R�A�𑝉������郁�\�b�h
    // �O������A�N�Z�X���邩��public�Œ�`������
    public void AddScore(int amount)
    {
        totalScore += amount;
        scoreText.text = "Score" + totalScore;
    }
    public int GetScore()
    {
        return totalScore;
    }
}
