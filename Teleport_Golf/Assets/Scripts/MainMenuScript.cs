using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {

        // Loading the Scene.
        SceneManager.LoadScene("SampleScene");

    }

    public void SettingsMenu()
    {

    // Loading the Scene.
    SceneManager.LoadScene("SettingsMenuUI_Scene");

    }

    public void QuitGame()
    {

        Application.Quit();

    }
}
