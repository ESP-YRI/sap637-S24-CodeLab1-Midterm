using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KingBehavior : MonoBehaviour
{
    public TextMeshProUGUI kingText;

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        kingText.text = "...Make your choice.";
    }
}
