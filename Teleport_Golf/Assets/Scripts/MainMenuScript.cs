using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public AudioSource BackgroundMusicAudio;
    public AudioSource ButtonAudio;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusicAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {

        ButtonAudio.Play();
        // Loading the Scene.
        SceneManager.LoadScene("SampleScene");

    }

    public void SettingsMenu()
    {

        ButtonAudio.Play();
    // Loading the Scene.
    SceneManager.LoadScene("SettingsMenuUI_Scene");

    }

    public void QuitGame()
    {
        ButtonAudio.Play();
        Application.Quit();

    }
}
