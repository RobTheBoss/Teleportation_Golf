using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitsHudUpdate : MonoBehaviour
{
    private TextMeshProUGUI hitText;

    // Start is called before the first frame update
    void Start()
    {
        hitText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        hitText.text = GameManager.hits.ToString();
    }
}
