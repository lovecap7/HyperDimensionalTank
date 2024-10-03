using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // ��������
    [SerializeField] int timeLimit;

    // �^�C�}�[�p�e�L�X�g
    [SerializeField] TextMeshProUGUI timerText;
 
        
    // �o�ߎ���
    float time;
    private void Start()
    {
        //�t���[�����[�g��60fps�ɂ���
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        // �t���[�����̌o�ߎ��Ԃ�time�ϐ��ɒǉ�
        time += Time.deltaTime;
        
        // time�ϐ��ɂ�int�^�ɂ��������Ԃ������������int�^��limit�^�̂ɑ��
        int remaining = timeLimit - (int)time;
        // timerText���X�V���Ă���
        timerText.text = $"�̂��� : {remaining.ToString("D3")}";

        if(remaining < 0 )
        {

        }
        
    }
}
