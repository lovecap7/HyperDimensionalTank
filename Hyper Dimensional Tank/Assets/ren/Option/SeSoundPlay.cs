using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;

public class SeSoundPlay : MonoBehaviour
{
    //SE
    [SerializeField] private AudioClip seSound;
    //public AudioClip beamSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    //public void OnDecide(InputAction.CallbackContext context)
    //{
    //    if (context.started) // �{�^�����������Ƃ�
    //    {
    //        audioSource.PlayOneShot(seSound);
    //    }     
    //}

    public void OnCursorMove(InputAction.CallbackContext context)
    {
        if (context.started) // �{�^�����������Ƃ�
        {
            audioSource.PlayOneShot(seSound);
        }
    }
}