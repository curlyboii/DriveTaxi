using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChange : MonoBehaviour
{

    public Color[] color;

    // Start is called before the first frame update
    void Start()
    {

        int randomColor = Random.Range(0, 30);

        Camera.main.backgroundColor = color[randomColor];

    }


}
