using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Title : MonoBehaviour
{
    int cursorNum = 1;
    GameObject cursor;
    // �_�ł�����Ώ�
    private Renderer _Cursor;
    // �_�Ŏ���
    private float _cycle = 1;

    private double _time;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Cursor").gameObject;
       // _Cursor = ;
    }

    // Update is called once per frame
    void Update()
    {
        // W�L�[����������cursorNum��1���
        if (Input.GetKeyDown(KeyCode.W))
        {
            cursorNum = 1;
            cursor.transform.localPosition = new Vector3(-110,-50,0);
        }
        // S�L�[����������cursorNum��2���
        if (Input.GetKeyDown(KeyCode.S))
        {
            cursorNum = 2;
            cursor.transform.localPosition = new Vector3(-110, -110, 0);
        }

        // �X�y�[�X�L�[�������ꂽ�猈��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cursorNum == 1)
            {
                Debug.Log("�Q�[���X�^�[�g");
            }
            if (cursorNum == 2)
            {
                Debug.Log("�I�v�V����");
            }
        }
        // �����������o�߂�����
        _time += Time.deltaTime;
        // ����cycle�ŌJ��Ԃ��l�̎擾
        // 0~cycle�͈̔͂̒l��������
        var repeatValue = Mathf.Repeat((float)_time, _cycle);
        // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
        _Cursor.enabled = repeatValue >= _cycle * 0.5f;
    }
}
