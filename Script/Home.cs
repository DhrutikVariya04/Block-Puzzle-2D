using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    void Update()
    {
        
    }

    public void Classic()
    {
        AudioManager.Audio.ClickSound();
        SceneManager.LoadScene("Play Screen"/*,LoadSceneMode.Additive*/);
    }
}
