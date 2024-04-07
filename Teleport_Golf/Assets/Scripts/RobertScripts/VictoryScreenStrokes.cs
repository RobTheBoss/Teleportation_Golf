using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreenStrokes : MonoBehaviour
{
    private TextMeshProUGUI strokeText;

    // Start is called before the first frame update
    void Start()
    {
        int strokes = GameManager.hits;

        strokeText.text = "Congrats, you won with " + strokes.ToString() + " strokes";

        GameManager.hits = 0;
    }
}
