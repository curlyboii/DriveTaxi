using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameStarted;

    public GameObject spawnerPlatforms;// we need reference to platform to stop generating when car fall


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


    }

    public void GameOver()
    {
        spawnerPlatforms.SetActive(false);

    }
}
