using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool levelOver = false;

    // checks how many npcs have not been interacted with and stores that number
    void Start()
    {
        interactableNPCS = GameObject.FindGameObjectsWithTag("Interactable");
        interactionsLeft = interactableNPCS.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //once all npcs have been either killed or spared, loads the next level after 1.5 seconds
        if (interactionsLeft == 0 && levelOver == false && ASCIILevelLoader.Instance.CurrentLevel < 5)
        {
            screenText.text = "Proceed.";
            Invoke("NextLevel", 1.5f);
            levelOver = true;
        }
        
        if (ASCIILevelLoader.Instance.CurrentLevel > 4)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    //increments CurrentLevel from the ASCIILevelLoader and thus sends the player to the next level
    public void NextLevel()
    {
        ASCIILevelLoader.Instance.CurrentLevel++;
    }
}
