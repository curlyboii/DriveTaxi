using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool moveLeft = true; // currently moving to the left
    bool firstInput = true;

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

        }

    }


}
