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

    public GameObject gameplayUI;


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
        StartCoroutine(UpdateScore());

    }

    public void GameOver()
    {
        spawnerPlatforms.SetActive(false);
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
}
