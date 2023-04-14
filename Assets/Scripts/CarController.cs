using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool moveLeft = true; // currently moving to the left
    bool firstInput = true;
    public GameObject pickUpEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)
        {
            GameManager.instance.GameOver();

        }

        if (GameManager.instance.score == 10)
        {
            moveSpeed = 7.35f; 

        }
        else if (GameManager.instance.score == 25)
        {
            moveSpeed = 7.7f;
        }
        else if (GameManager.instance.score == 50)
        {
            moveSpeed = 8f;
        }
        else if (GameManager.instance.score == 75)
        {
            moveSpeed = 8.5f;
        }
        else if (GameManager.instance.score == 100)
        {
            moveSpeed = 9f;
        }
        else if (GameManager.instance.score == 125)
        {
            moveSpeed = 10f;
        }
        else if (GameManager.instance.score == 150)
        {
            moveSpeed = 11f;
        }
        else if (GameManager.instance.score == 175)
        {
            moveSpeed = 12f;
        }
        else if (GameManager.instance.score == 200)
        {
            moveSpeed = 13f;
        }
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }


    void CheckInput() //when the player touching
    {

        //first input ignore
        if(firstInput)
        {
            firstInput = false;
            return;

        }

        if(Input.GetMouseButtonDown(0))
        {

            ChangeDirection();

        }

    }


    void ChangeDirection()
    {
        if(moveLeft)
        {
            moveLeft = false;
            transform.rotation = Quaternion.Euler(0,90,0);

        }
        else
        {
            moveLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {

            other.gameObject.SetActive(false);
            GameManager.instance.CollectCrystal();
            AudioManager.instance.PickedUp();
            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);

        }

    }


}
