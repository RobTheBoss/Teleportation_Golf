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
    public float dragCo;
    bool clickedDown = false;

    [SerializeField] float maxPower = 35f;
    [SerializeField] float minPower = 0.5f;

    public float powerVisual = 0.0f;

    private GameObject arrow;

    public AudioSource LaunchBallAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;

        arrow = GameObject.FindGameObjectWithTag("Arrow");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.6f)
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

            if (clickedDown)
            {
                Vector2 endDragPosVisual = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //arrow.transform.rotation = Quaternion.LookRotation((Vector3)endDragPosVisual - transform.position);

                arrow.SetActive(true);
                Vector3 aimDirection = (Vector3)endDragPosVisual - transform.position;
                if (aimDirection != Vector3.zero)
                {
                    float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                }

                powerVisual = (Mathf.Clamp(Vector2.Distance(transform.position, endDragPosVisual) * 12f, minPower, maxPower) - minPower) / (maxPower - minPower);
            }
            else
                arrow.SetActive(false);

            Time.timeScale = 1.0f;
        }

        if (!ballStationary)
        {
            Time.timeScale = 0.3f;
            LinearDrag();
        }
    }

    private void Launch()
    {
        LaunchBallAudio.Play();
        Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        Vector2 dir = (temp - endDragPos).normalized;
        float power = Mathf.Clamp(Vector2.Distance(temp, endDragPos) * 12f, minPower, maxPower);

        rb.velocity = dir * power * (1 / Time.timeScale);

        GameManager.hits++;
    }

    public void BumpLaunch(float power, Vector2 dir)
    {
        rb.velocity = dir * power * (1 / Time.timeScale);
    }

    private void LinearDrag()
    {
        Vector2 linearDrag = rb.velocity * dragCo;
        rb.velocity -= linearDrag * Time.fixedDeltaTime;
    }
}
