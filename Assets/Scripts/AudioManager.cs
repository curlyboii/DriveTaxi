using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public AudioSource audioSource;
    public AudioClip[] gameMusic;

    public static AudioManager instance;

    private bool musicStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource= GetComponent<AudioSource>();
    }

    void Update()
    {
        /*new boolean flag variable musicStarted is added and set to false by default.
        Then, in the Update() method, you check if the GameManager game has started and the music hasn't already
        started playing (!musicStarted). If this condition is true, the StartMusic() method is called and the musicStarted
        flag is set to true. This ensures that the music is played only once when the game starts, and not repeatedly*/
        if (GameManager.instance.gameStarted && !musicStarted) 
        {
            audioSource.clip = gameMusic[1];
            audioSource.Play();
            musicStarted = true;
        }
    }
}
