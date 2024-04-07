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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Golfball"))
        {
            ballRB.AddForce(transform.up * speed * 50 * Time.timeScale);
            Debug.Log("Pushing");
        }
    }
}
