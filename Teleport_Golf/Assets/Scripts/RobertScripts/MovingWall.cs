using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    public AnimationCurve animationCurve;

    private Vector2 point1;
    [SerializeField] Vector2 point2;
    [SerializeField] float speedMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        point1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(point1, point2, animationCurve.Evaluate(Time.time * speedMultiplier));
    }
}
