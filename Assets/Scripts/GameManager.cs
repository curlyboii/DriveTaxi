using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameStarted;

    public GameObject spawnerPlatforms;// we need reference to platform to stop generating when car fall

    int score = 0;

    public Text scoreText;
    public Text bestScoreText;
    int bestScore = 0; 

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
}
