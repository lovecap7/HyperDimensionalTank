using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class AudioMixerScript : MonoBehaviour
{
    private Vector2 inputMove;
    private int selectIndex = 4;
    [SerializeField] GameObject corsol;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    private float setDecibel;
    // Start is called before the first frame update
    void Start()
    {
        
        masterSlider.value = PlayerPrefs.GetFloat("MasterValue", 1f);
        bgmSlider.value = PlayerPrefs.GetFloat("BgmValue", 1f);
        seSlider.value = PlayerPrefs.GetFloat("SeValue", 1f);
        if (masterSlider != null)
        {
            masterSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -100f, 0f);
                PlayerPrefs.SetFloat("MasterDecibel", decibel);
                audioMixer.SetFloat("Master_Volume", decibel);
            });
        }
        if (bgmSlider != null)
        {
            bgmSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -100f, 0f);
                PlayerPrefs.SetFloat("BgmDecibel", decibel);
                audioMixer.SetFloat("BGM_Volume", decibel);
            });
        }
        if (seSlider != null)
        {
            seSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -100f, 0f);
                PlayerPrefs.SetFloat("SeDecibel", decibel);
                audioMixer.SetFloat("SE_Volume", decibel);
            });
        }

        //保存された音量をセットする
        setDecibel = PlayerPrefs.GetFloat("MasterDecibel", 0f);
        audioMixer.SetFloat("Master_Volume", setDecibel);
        setDecibel = PlayerPrefs.GetFloat("BgmDecibel", 0f);
        audioMixer.SetFloat("BGM_Volume", setDecibel);
        setDecibel = PlayerPrefs.GetFloat("SeDecibel", 0f);
        audioMixer.SetFloat("SE_Volume", setDecibel);

    }

    // Update is called once per frame
    void Update()
    {
        if(selectIndex == 4)
        {
            Debug.Log("Master");
            masterSlider.value += 0.001f * inputMove.x;
            corsol.transform.localPosition = new Vector3(-300,215,0);
        }
        if (selectIndex == 3)
        {
            Debug.Log("BGM");
            bgmSlider.value += 0.001f * inputMove.x;
            corsol.transform.localPosition = new Vector3(-300, 75, 0);
        }
        if (selectIndex == 2)
        {
            Debug.Log("SE");
            seSlider.value += 0.001f * inputMove.x;
            corsol.transform.localPosition = new Vector3(-300, -75, 0);
        }
        if(selectIndex == 1)
        {
            corsol.transform.localPosition = new Vector3(-177, -220, 0);
        }
    }

    public void OnSaveValue(InputAction.CallbackContext context)
    {
        if (selectIndex == 1)
        {
            Debug.Log("保存");
            float masterValue = masterSlider.value;
            PlayerPrefs.SetFloat("MasterValue", masterValue);
            float bgmValue = bgmSlider.value;
            PlayerPrefs.SetFloat("BgmValue", bgmValue);
            float seValue = seSlider.value;
            PlayerPrefs.SetFloat("SeValue", seValue);
        }
    }

    public void OnChangeValue(InputAction.CallbackContext context)
    {
        // 入力値を保持しておく
        inputMove = context.ReadValue<Vector2>();
        if (context.started) // ボタンを押したとき
        {
            Debug.Log(inputMove);
            if(inputMove.y < -0.02f)
            {
                selectIndex -= 1;
            }
            else if (inputMove.y > 0.02f)
            {
                selectIndex += 1;
            }
           
        }
           
        if (selectIndex > 4)
        {
            selectIndex = 4;
        }
        if (selectIndex < 0)
        {
            selectIndex = 0;
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("ModeSelectScene");
    }
}
