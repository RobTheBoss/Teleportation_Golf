using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class GolfBall : MonoBehaviour
{
    Vector2 startDragPos = Vector2.zero;
    Vector2 endDragPos = Vector2.zero;
    private Rigidbody2D rb;
    bool ballStationary = true;
    public float origdragCo;
    [HideInInspector] public float dragCo;
    bool applyDrag = false;
    bool clickedDown = false;

    [SerializeField] float maxPower = 35f;
    [SerializeField] float minPower = 0.5f;

    public float powerVisual = 0.0f;

    private GameObject arrow;

    public AudioSource LaunchBallAudio;

    [SerializeField] bool usingTouchInput = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;

        arrow = GameObject.FindGameObjectWithTag("Arrow");

        dragCo = origdragCo;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < 5.0f)
            dragCo = origdragCo * 5f;
        else
            dragCo = origdragCo;

        if (rb.velocity.magnitude > 0.6f)
            ballStationary = false;
        else
        {
            ballStationary = true;
            rb.velocity = Vector2.zero;
        }

        if (ballStationary)
        {
            if (!usingTouchInput)
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
            else if (usingTouchInput)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    startDragPos = touch.position;
                    startDragPos = Camera.main.ScreenToWorldPoint(startDragPos);
                    clickedDown = true;
                }
                else if (touch.phase == TouchPhase.Ended && clickedDown)
                {
                    endDragPos = touch.position;
                    endDragPos = Camera.main.ScreenToWorldPoint(endDragPos);

                    clickedDown = false;
                    Launch();
                }
            }


            if (clickedDown)
            {
                Vector2 endDragPosVisual = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (usingTouchInput)
                    endDragPosVisual = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                //arrow.transform.rotation = Quaternion.LookRotation((Vector3)endDragPosVisual - transform.position);

                arrow.SetActive(true);
                Vector3 aimDirection = (Vector3)endDragPosVisual - transform.position;
                if (aimDirection != Vector3.zero)
                {
                    float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                }


                powerVisual = (Mathf.Clamp(Vector2.Distance(transform.position, endDragPosVisual) * 12f, minPower, maxPower) - minPower) / (maxPower - minPower);
                if (usingTouchInput)
                    powerVisual = (Mathf.Clamp(Vector2.Distance(transform.position, endDragPosVisual) * 8f, minPower, maxPower) - minPower) / (maxPower - minPower);
            }
            else
            {
                arrow.SetActive(false);
            }
        }

        if (!ballStationary)
        {
            applyDrag = true;

            Time.timeScale = 0.3f;
        }
        else
        {
            Time.timeScale = 1.0f;
            applyDrag = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainLevel");
            GameManager.hits = 0;
        }
    }

    private void Launch()
    {
        LaunchBallAudio.Play();
        Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        Vector2 dir = (temp - endDragPos).normalized;
        float power = Mathf.Clamp(Vector2.Distance(temp, endDragPos) * 12f, minPower, maxPower);

        if (usingTouchInput) 
            power = Mathf.Clamp(Vector2.Distance(temp, endDragPos) * 8f, minPower, maxPower);

        rb.velocity = dir * power * (1 / Time.timeScale);

        Debug.Log(power);

        GameManager.hits++;
    }

    public void BumpLaunch(float power, Vector2 dir)
    {
        rb.velocity = dir * power * (1 / Time.timeScale);
    }

    private void FixedUpdate()
    {
        if (!applyDrag) return;

        Vector2 linearDrag = rb.velocity * dragCo;
        rb.velocity -= linearDrag * Time.fixedDeltaTime;
    }
}
