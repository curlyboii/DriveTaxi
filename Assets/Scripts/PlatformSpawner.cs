using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject spawnerPlatform; //new platform
    public Transform lastPlatform; 
    Vector3 lastPosition;
    Vector3 newPosition;
    bool stop;


    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SpawnPlatforms()
    {

        while(!stop)
        {
            GeneratePosition();
            Instantiate(spawnerPlatform, newPosition, Quaternion.identity);
            lastPosition = newPosition;
            yield return new WaitForSeconds(0.1f);
        }

      
    }

    //void SpawnPlatform()
    //{
    //    GeneratePosition();
    //    Instantiate(spawnerPlatform, newPosition, Quaternion.identity);
    //    lastPosition = newPosition;
    //}



    void GeneratePosition()
    {
        int random = Random.Range(0, 2);

        newPosition = lastPosition;

        if (random > 0)
        {
            newPosition.x += 2f;

        }
        else 
        {

            newPosition.z += 2f;

        }

       

    }
}
