using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{

    public static ASCIILevelLoader Instance;

    private int currentLevel = 0;
    private string FILE_PATH;

    public GameObject level;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
            LoadLevel();
        }
    }

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

    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + "/Levels/Levelnum.txt";
        LoadLevel();
    }

    public void LoadLevel()
    {
        Destroy(level);
        level = new GameObject("Level Objects");

        if (currentLevel < 5)
        {

            //Gets all the lines from the text file containing the level we want to load and puts them in an array
            string[] lines = File.ReadAllLines(FILE_PATH.Replace("num", currentLevel + ""));

            //use y here because we're positioning it on the y axis
            for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
            {
                //toupper just changes all of the chars in the string to capital letters
                //because == with chars IS case sensitive (a =/= A)
                string line = lines[yLevelPos].ToUpper();
                //turn that single line into an array of chars
                char[] characters = line.ToCharArray();

                for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
                {
                    char c = characters[xLevelPos];

                    GameObject newObject = null;

                    switch (c)
                    {

                        case 'P':
                            newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
                            //the camera will follow the last player that is made
                            Camera.main.transform.parent = newObject.transform;
                            //and that player will be centered
                            Camera.main.transform.position = new Vector3(0, 0, -10);
                            break;

                        case 'B':
                            newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Block"));
                            break;

                        case 'S':
                            newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Soldier"));
                            break;

                        case 'K':
                            newObject = Instantiate(Resources.Load<GameObject>("Prefabs/King"));
                            break;

                        case 'G':
                            newObject = Instantiate(Resources.Load<GameObject>("Prefabs/Guard"));
                            break;

                        default:
                            break;
                    }

                    if (newObject != null)
                    {
                        //parents all the new objects to the level 
                        newObject.transform.parent = level.transform;

                        //ensures that the objects are where you want them to be per the ASCII file
                        //position in level based on position in ascii file
                        newObject.transform.position = new Vector3(xLevelPos, -yLevelPos, 0);
                    }
                }

            }

            //every time a new level loads, the "interactionsLeft" variable must be updated
            //so, I update it here after the level is done loading in
            GameManager.Instance.interactableNPCS = GameObject.FindGameObjectsWithTag("Interactable");
            GameManager.Instance.interactionsLeft = GameManager.Instance.interactableNPCS.Length;
            GameManager.Instance.levelOver = false;
        }
    }
}
