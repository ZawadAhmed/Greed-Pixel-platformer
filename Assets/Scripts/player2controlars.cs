using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class player2controlars : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] player1controlars player1;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    float horizontalInput;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        horizontalInput = 0;

    }
    private void Update()
    {
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (Input.GetKey(KeyCode.Keypad4))
        {
            horizontalInput = -1;

            transform.localScale = Vector3.one;
        }


        if (Input.GetKey(KeyCode.Keypad6))
        {
            horizontalInput = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.Keypad4)) horizontalInput = 0;
 

        //jump
        if (Input.GetKey(KeyCode.Keypad8) && grounded)
            jump();

        //switching from idel to another animation 
        anim.SetBool("run", horizontalInput != 0);

    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;

        if (collision.gameObject.CompareTag("Trap"))
        {
            die(true);

        }
    }

    private void die(bool iDie)
    {
        body.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");

        player1.on2Death(iDie);
    }
    public void on1Death(bool sheDead)
    {
        if (sheDead)
            body.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
    }
    private void restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        public void tp(){

        if(player1.openDoorChecker1()){
             //SceneManager.LoadScene("Scene3");
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    public bool openDoorChecker2 (){
        return true;
    }

}
