using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private bool startTimer = false;
    private float timer = 5f;

    public AudioSource Victory_SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {


            timer -= Time.unscaledDeltaTime;

            if (timer < 0 )
                SceneManager.LoadScene("WinScreenUI_Scene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Golfball"))
        {
            collision.gameObject.SetActive(false);

            Victory_SoundEffect.Play();

            startTimer = true;
        }
    }
}
