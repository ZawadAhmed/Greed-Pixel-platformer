using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] movingPlatForm _movingPlatForm;

    Vector3 _buttonUpPos;
    Vector3 _buttonDownPos;
    float _buttonSizeY;
    float _buttonSpeed = 1f;
    
  


    private void Awake()
    {
        _buttonSizeY = transform.localScale.y / 2;
        _buttonUpPos = transform.position;
        _buttonDownPos = new Vector3(transform.position.x, transform.position.y - _buttonSizeY, transform.position.z);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("gameObj"))
        {
            transform.position = Vector3.MoveTowards(transform.position, _buttonDownPos, _buttonSpeed * Time.deltaTime);
         
            
            _movingPlatForm.move = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("gameObj"))
        {
            transform.position = Vector3.MoveTowards(transform.position, _buttonUpPos, _buttonSpeed * Time.deltaTime);

            _movingPlatForm.move = false;
        }
    }
   
}
