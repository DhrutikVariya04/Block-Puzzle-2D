using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Toggle Vibrate, sound;

    private void OnEnable()
    {
        sound.SetIsOnWithoutNotify(AudioManager.Audio.isBgMusicOn());
    }

    public void MuteSound() 
    {
        if (sound.isOn)
        {
            AudioManager.Audio.BGMusic(true);
        }
        else
        {
            AudioManager.Audio.BGMusic(false);
        }
    }

    public void Close()
    {
        AudioManager.Audio.ClickSound();
        gameObject.SetActive(false);
    }
}
