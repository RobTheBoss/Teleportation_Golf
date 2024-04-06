using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

[RequireComponent(typeof(Rigidbody2D))]

public class GolfBall : MonoBehaviour
{
    Vector2 startDragPos = Vector2.zero;
    Vector2 endDragPos = Vector2.zero;
    private Rigidbody2D rb;
    bool ballStationary = true;
    public float dragCo = 0.5f;
    bool clickedDown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.1f)
            ballStationary = false;
        else
        {
            ballStationary = true;
            rb.velocity = Vector2.zero;
        }

        if (ballStationary)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startDragPos = Input.mousePosition;
                startDragPos = Camera.main.ScreenToWorldPoint(startDragPos);
                clickedDown = true;
            }
            else if (Input.GetMouseButtonUp(0) && clickedDown)
            {
                endDragPos = Input.mousePosition;
                endDragPos = Camera.main.ScreenToWorldPoint(endDragPos);

                clickedDown = false;
                Launch();
            }
        }

        if (!ballStationary)
        {
            LinearDrag();
        }
    }

    private void Launch()
    {
        Vector2 dir = (startDragPos - endDragPos).normalized;
        float power = Mathf.Clamp(Vector2.Distance(startDragPos, endDragPos), 0.2f, 10.0f);

        Debug.Log(power);

        rb.velocity = dir * power * (1 / Time.timeScale);
    }

    private void LinearDrag()
    {
        Vector2 linearDrag = rb.velocity * dragCo;
        rb.velocity -= linearDrag * Time.fixedDeltaTime;
    }
}
