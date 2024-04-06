using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    private float defaultDragCo;
    private float stickyDragCo;
    [SerializeField] float stickinessMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        defaultDragCo = GameObject.FindGameObjectWithTag("Golfball").GetComponent<GolfBall>().dragCo;
        stickyDragCo = defaultDragCo * stickinessMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Golfball"))
        {
            collision.gameObject.GetComponent<GolfBall>().dragCo = stickyDragCo;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Golfball"))
        {
            collision.gameObject.GetComponent<GolfBall>().dragCo = defaultDragCo;
        }
    }
}
