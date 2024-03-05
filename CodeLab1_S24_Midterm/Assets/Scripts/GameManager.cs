using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject[] interactableNPCS;
    public TextMeshProUGUI screenText;
    public int interactionsLeft;

    // Start is called before the first frame update
    void Start()
    {
        interactableNPCS = GameObject.FindGameObjectsWithTag("Interactable");
        interactionsLeft = interactableNPCS.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionsLeft == 0)
        {
            screenText.text = "Move On!";
        }
        
    }
}
