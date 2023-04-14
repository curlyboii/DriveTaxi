using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject diamond;



    // Start is called before the first frame update
    void Start()
    {
        int randomDiamond = Random.Range(0, 10); //chance

        Vector3 diamondPosition = transform.position; // platform position

        diamondPosition.y += 1f; 

        if(randomDiamond < 1) //if 0 - spawn
        {
            GameObject diamondInstance = Instantiate(diamond, diamondPosition, diamond.transform.rotation);
            diamondInstance.transform.SetParent(gameObject.transform); //platform parent
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.25f);

        }
    }

    void Fall()
    { 
    
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    
    }
}



