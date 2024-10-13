using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;
using UnityEngine.InputSystem;

public class SeSoundPlay : MonoBehaviour
{
    //SE
    [SerializeField] private AudioClip[] seSound = new AudioClip[3];
    //public AudioClip beamSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void OnDecide(InputAction.CallbackContext context)
    {
        if (context.started) // ボタンを押したとき
        {
            audioSource.PlayOneShot(seSound[0]);
        }     
    }

    public void OnCursorMove(InputAction.CallbackContext context)
    {
        if (context.started) // ボタンを押したとき
        {
            audioSource.PlayOneShot(seSound[1]);
        }
    }
}