using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSliderHud : MonoBehaviour
{
    private GolfBall ball;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponentInParent<GolfBall>();
        slider = GetComponentInParent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = ball.powerVisual;
    }
}
