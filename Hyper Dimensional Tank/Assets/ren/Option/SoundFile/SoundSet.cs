using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundSet : MonoBehaviour
{
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
}
