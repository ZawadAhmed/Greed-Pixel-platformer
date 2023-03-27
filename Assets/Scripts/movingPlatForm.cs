using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatForm : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoint;
    private Vector3 originalPos;
    private int currentIndex = 0;
    public bool move = false;
    


    [SerializeField] private float speed = 2f;
    private void Awake()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        
        if (move)
        {
        if (Vector2.Distance(wayPoint[currentIndex].transform.position, transform.position) < .1f)
        {
            currentIndex++;
            if (currentIndex >= wayPoint.Length)
            {
                currentIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoint[currentIndex].transform.position, Time.deltaTime * speed);
        }
        else
        {
           transform.position = Vector2.MoveTowards(transform.position, originalPos, Time.deltaTime * speed);
        }
    }
        

}
