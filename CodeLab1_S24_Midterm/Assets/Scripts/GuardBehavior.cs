using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    public TextMeshProUGUI guardText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        guardText.text = "I won't let you hurt him!";
    }
}
