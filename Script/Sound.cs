using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource PlaySound;
    [SerializeField] AudioClip Clickclip;

    public static AudioManager Audio;

    private void Awake()
    {
        Audio = this;
    }
    public void ClickSound()
    {
        PlaySound.clip = Clickclip;
        PlaySound.Play();
    }
}
