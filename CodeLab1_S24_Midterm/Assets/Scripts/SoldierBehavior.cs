using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierBehavior : MonoBehaviour
{
    public TextMeshProUGUI soldierText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        soldierText.text = "Halt!";
    }
}
