using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] float lerpSpeed;
    [SerializeField] bool hardFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Golfball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (hardFollow)
        {
            transform.position = Vector2.Lerp(transform.position, player.position, 1);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, player.position, lerpSpeed * Time.unscaledDeltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}
