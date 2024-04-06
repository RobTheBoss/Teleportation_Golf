using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuUI_Script : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {

        // Loading the Scene.
        SceneManager.LoadScene("MainMenuUI_Scene");

    }

}
