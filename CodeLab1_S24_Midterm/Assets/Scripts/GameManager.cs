using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    private bool gameOver = false;

    private int timesPlayed = 0;
    private string PLAY_HISTORY_FILE_PATH;
    const string HISTORY_DIR = "/Data/";
    const string HISTORY_FILE = "history.txt";

    //stores the number of times the game has been played in a file
    public int TimesPlayed
    {
        get
        {
            if (File.Exists(PLAY_HISTORY_FILE_PATH))
            {
                string fileContent = File.ReadAllText(PLAY_HISTORY_FILE_PATH);
                timesPlayed = Int32.Parse(fileContent);
            }
            return timesPlayed;
        }

        set
        {
            timesPlayed = value;
            string fileContent = "" + timesPlayed;

            if (!Directory.Exists(Application.dataPath + HISTORY_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + HISTORY_DIR);
            }
            
            File.WriteAllText(PLAY_HISTORY_FILE_PATH, fileContent);
        }
    }
    
    // checks how many npcs have not been interacted with and stores that number
    // also increments the timesPlayed counter
    void Start()
    {
        interactableNPCS = GameObject.FindGameObjectsWithTag("Interactable");
        interactionsLeft = interactableNPCS.Length;
        PLAY_HISTORY_FILE_PATH = Application.dataPath + HISTORY_DIR + HISTORY_FILE;
        TimesPlayed++;
    }

    void Update()
    {
        if (interactionsLeft > 0)
        {
            screenText.text = "Their fates are in your hands.\nPress \"K\" to kill or \"L\" to spare.";
        }
        
        //once all npcs have been either killed or spared, tells the player to hit P
        //doing so will loads the next level after .1 seconds
        //unless there are no levels left
        if (interactionsLeft == 0 && levelOver == false && ASCIILevelLoader.Instance.CurrentLevel < 5)
        {
            screenText.text = "Hit P to Proceed.";
            if (Input.GetKey(KeyCode.P))
            {
                Invoke("NextLevel", .1f);
                levelOver = true;
            }
        }
        
        //once you've beaten the last level, sends you to the end screen
        if (ASCIILevelLoader.Instance.CurrentLevel > 4 && !gameOver)
        {
            SceneManager.LoadScene("EndScreen");
            //the below is there to prevent the game from reloading the end scene over and over
            gameOver = true;
        }
    }

    //increments CurrentLevel from the ASCIILevelLoader and thus sends the player to the next level
    public void NextLevel()
    {
        ASCIILevelLoader.Instance.CurrentLevel++;
    }
}
