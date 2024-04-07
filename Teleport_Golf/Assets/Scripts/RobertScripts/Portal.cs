using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    static float cooldownTotal = 1.0f;
    static float cooldown = 0.0f;
    static bool canTeleport = true;

    public AudioSource Portal_SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            canTeleport = false;
            cooldown -= Time.unscaledDeltaTime;
        }
        else
        {
            canTeleport = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Golfball") && canTeleport && otherPortal != null)
        {
            Portal_SoundEffect.Play();
            cooldown = cooldownTotal;
            collision.transform.position = otherPortal.position;
        }
    }
}
