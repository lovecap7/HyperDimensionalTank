using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerScript : MonoBehaviour
{
    [SerializeField] private GameObject soundPanel;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    private float setDecibel;
    // Start is called before the first frame update
    void Start()
    {
        soundPanel.SetActive(false);
        masterSlider.value = PlayerPrefs.GetFloat("MasterValue", 0.2f);
        bgmSlider.value = PlayerPrefs.GetFloat("BgmValue", 0.2f);
        seSlider.value = PlayerPrefs.GetFloat("SeValue", 0.2f);
        if (masterSlider != null)
        {
            masterSlider.onValueChanged.AddListener((value) =>
            {
                value = Mathf.Clamp01(value);

                float decibel = 20f * Mathf.Log10(value);
                decibel = Mathf.Clamp(decibel, -80f, 0f);
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
                decibel = Mathf.Clamp(decibel, -80f, 0f);
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
                decibel = Mathf.Clamp(decibel, -80f, 0f);
                PlayerPrefs.SetFloat("SeDecibel", decibel);
                audioMixer.SetFloat("SE_Volume", decibel);
            });
        }

        //•Û‘¶‚³‚ê‚½‰¹—Ê‚ðƒZƒbƒg‚·‚é
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
        
    }

    public void OnSaveValue()
    {
        float masterValue = masterSlider.value;
        PlayerPrefs.SetFloat("MasterValue", masterValue);
        float bgmValue = bgmSlider.value;
        PlayerPrefs.SetFloat("BgmValue", bgmValue);
        float seValue = seSlider.value;
        PlayerPrefs.SetFloat("SeValue", seValue);
        soundPanel.SetActive(false);
    }

    public void OnPanelTrue()
    {
        soundPanel.SetActive(true);
    }
}
