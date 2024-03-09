using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KingBehavior : MonoBehaviour
{
    public TextMeshProUGUI kingText;

    void Start()
    {
        if (GameManager.Instance.TimesPlayed == 1)
        {
            kingText.text = "You… Why have you come here? What do you intend to do?";
        }
        
        if (GameManager.Instance.TimesPlayed == 2)
        {
            kingText.text = "You… WE have been here before. " +
                            "I remember not what you did, nor ever having met you, but I recognize you. " +
                            "Why are you back again?";
        }
        
        if (GameManager.Instance.TimesPlayed == 3)
        {
            kingText.text = "You are here again. I know why now. ";
        }
        
        if (GameManager.Instance.TimesPlayed == 4)
        {
            kingText.text = "You enjoy toying with us.";
        }
        
        if (GameManager.Instance.TimesPlayed >= 5)
        {
            kingText.text = "...Just get it over with.";
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        kingText.text = "...";
    }
}
