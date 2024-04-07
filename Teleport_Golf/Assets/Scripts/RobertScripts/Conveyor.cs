using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Conveyor : MonoBehaviour
{
    RawImage rawImage;
    [SerializeField] float speed;
    private Rigidbody2D ballRB;

    private bool shouldAddForce = false;
    public AudioSource Conveyor_SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponentInChildren<RawImage>();
        ballRB = GameObject.FindGameObjectWithTag("Golfball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(0, -speed) * Time.deltaTime, rawImage.uvRect.size);
    }

    private void FixedUpdate()
    {
        if (shouldAddForce)
            ballRB.AddForce(transform.up * speed * 100 * Time.timeScale);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Golfball"))
        {
            shouldAddForce = true;

            Debug.Log("Pushing");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Golfball"))
        {
            Conveyor_SoundEffect.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        shouldAddForce = false;

        if (collision.CompareTag("Golfball"))
        {
            Conveyor_SoundEffect.Stop();
        }
    }
}
