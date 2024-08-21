using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource PlaySound,BG;
    [SerializeField] AudioClip Clickclip,BlockPlaceclip;
    
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

    public void BlockPlaceSound()
    {
        PlaySound.clip = BlockPlaceclip;
        PlaySound.Play();
    }

    public void BGMusic()
    {
        if(BG.mute == true)
        {
            BG.mute = false;
        }
        else
        {
            BG.mute = true;
        }
    }
}
