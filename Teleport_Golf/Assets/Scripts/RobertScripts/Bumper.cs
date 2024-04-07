using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float bumpPower;

    public AudioSource Bumper_SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //playerRB = GameObject.FindGameObjectWithTag("Golfball").GetComponent<GolfBall>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bumper_SoundEffect.Play();

        if (collision.gameObject.CompareTag("Golfball"))
        {
            Vector2 dir = (collision.transform.position - transform.position).normalized;

            collision.gameObject.GetComponent<GolfBall>().BumpLaunch(bumpPower, dir);
        }
    }
}
