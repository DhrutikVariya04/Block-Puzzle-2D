using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHome : MonoBehaviour
{
    [SerializeField]
    Toggle Vibrate, sound;

    public void MuteSound() 
    {
        AudioManager.Audio.BGMusic();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
