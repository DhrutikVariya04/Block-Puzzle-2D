using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject EventSystem;

    public static Home home;

    private void Awake()
    {
        home = this;
    }

    void Update()
    {
        
    }

    // When Player Click On classic Button :--
    public void Classic()
    {
        AudioManager.Audio.ClickSound();
        StartCoroutine(loadPlayScene());
    }

    IEnumerator loadPlayScene()
    {
        SceneManager.LoadScene("Play Screen", LoadSceneMode.Additive);

        yield return new WaitForSeconds(.25f);

        // Disable Camera And EventSystem :-
        DisActiveListner();
    }

    public void ActiveListner()
    {
        Camera.SetActive(true);
        EventSystem.SetActive(true);
    }

    public void DisActiveListner()
    {
        Camera.SetActive(false);
        EventSystem.SetActive(false);
    }
}
