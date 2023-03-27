using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float length, startpos;
    public float parallaxFactor;
    public GameObject cam;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {

        float temp = (cam.transform.position.x * (1 - parallaxFactor));
        float distance = cam.transform.position.x * parallaxFactor;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);


        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        
    }   
}