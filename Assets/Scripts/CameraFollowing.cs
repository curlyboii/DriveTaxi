using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target; // target obj
    Vector3 distance; // store diastance between target obj and our camera
    public float smoothValue; // smooth move

    // Start is called before the first frame update
    void Start()
    {
        distance= target.position - transform.position; // calculate distance between Target and Camera
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 0)
        {
            Follow();
        }

    }

    void Follow()
    {
        Vector3 currentPosition = transform.position; // current position our camera
        Vector3 targetPosition = target.position - distance;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, smoothValue * Time.deltaTime); //interpolate
    }
}
