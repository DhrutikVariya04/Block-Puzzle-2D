using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource PlaySound,BG;
    [SerializeField] AudioClip Clickclip, BlockPlaceclip;
    [SerializeField] AudioClip BloclkWrongPlaceclip, BlockExplodeclip;

    public static AudioManager Audio;

    private void Awake()
    {
        Audio = this;
    }

    internal void ClickSound()
    {
        PlaySound.clip = Clickclip;
        PlaySound.Play();
    }

    internal void BlockPlaceSound()
    {
        PlaySound.clip = BlockPlaceclip;
        PlaySound.Play();
    }

    internal void BlockWrongPlaceSound()
    {
        PlaySound.clip = BloclkWrongPlaceclip;
        PlaySound.Play();
    }

    internal void blockExplode()
    {
        PlaySound.clip = BlockExplodeclip;
        PlaySound.Play();
    }

    public void BGMusic(bool Value)
    {
        BG.mute = !Value;
    }

    public bool isBgMusicOn()
    {
        return !BG.mute;
    }
}
