using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
[Serializable]
public class PlayerData
{
    public int crystals;
}

public class GameManager : MonoBehaviour
{
    private PlayerData playerData; // This variable will be used to store the player's data, including the number of crystals they've collected

    public static GameManager instance;

    public bool gameStarted;

    public GameObject spawnerPlatforms;// we need reference to platform to stop generating when car fall

    int score = 0;

    public Text scoreText;
    public Text bestScoreText;
    int bestScore = 0;
    public Text crystalText; //show crystal

    public GameObject gameplayUI;
    public GameObject MenuUI;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best score: " + bestScore;
        LoadData();
        // initialize playerData object with default values
        if (playerData == null)
        {
            playerData = new PlayerData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
        Debug.Log("Crystals: " + playerData.crystals);

        crystalText.text = playerData.crystals.ToString();// update crystal on display

    }

    public void GameStart()
    {
        gameStarted = true;
        spawnerPlatforms.SetActive(true);
        gameplayUI.SetActive(true);
        MenuUI.SetActive(false);
        StartCoroutine("UpdateScore");

    }

    public void GameOver()
    {
        spawnerPlatforms.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveBestScore();
        Invoke("ReloadScene", 1f);

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Scene_0");
    }

    IEnumerator UpdateScore()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1f);

            score++;
            
            scoreText.text = score.ToString();

        }
    }

    void SaveBestScore()
    {

        if(PlayerPrefs.HasKey("BestScore"))
        {
            //if we have already best score
            if(score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
            }


        }
        else
        {
            // First play
            PlayerPrefs.SetInt("BestScore", score);

        }

    }

    void OnApplicationQuit()
    {
        SaveData();
    }

    private void LoadData()
    {
        // Get the file path where the player data should be saved
        string dataPath = Application.persistentDataPath + "/playerData.dat";

        // Check if the file exists
        if (File.Exists(dataPath))
        {
            // Create a new BinaryFormatter object to deserialize the data from the file
            BinaryFormatter formatter = new BinaryFormatter();

            // Create a FileStream object to read the data from the file
            FileStream stream = new FileStream(dataPath, FileMode.Open);

            // Deserialize the data from the file into the playerData object
            playerData = formatter.Deserialize(stream) as PlayerData;

            // Close the FileStream
            stream.Close();
        }
        else
        {
            // If the file does not exist, create a new PlayerData object
            playerData = new PlayerData();
        }
    }

    private void SaveData()
    {
        // Set the path for the data file to the persistent data path of the application, 
        // using the playerData.dat file name.
        string dataPath = Application.persistentDataPath + "/playerData.dat";

        // Create a new BinaryFormatter object for serializing the data.
        BinaryFormatter formatter = new BinaryFormatter();

        // Create a new FileStream object with the specified path and FileMode.Create, 
        // which will create a new file or overwrite an existing file with the same name.
        FileStream stream = new FileStream(dataPath, FileMode.Create);

        // Serialize the playerData object and write it to the stream using the formatter.
        formatter.Serialize(stream, playerData);

        // Close the stream to release any resources used by the FileStream object.
        stream.Close();
    }

    public void CollectCrystal()
    {
        playerData.crystals++;
        crystalText.text = "Crystal: " + playerData.crystals.ToString(); // update the text component to display the current amount of crystals
        SaveData(); // Save crystal
    }
}
