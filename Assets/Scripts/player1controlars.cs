using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1controlars : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] player2controlars player2;
    private Rigidbody2D body1;
    private Animator anim;
    private bool grounded;
    float horizontalInput1;
    private void Awake()
    {
        body1 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        horizontalInput1 = 0;
    }
    private void Update()
    {
        
        body1.velocity = new Vector2(horizontalInput1 * speed, body1.velocity.y);


        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput1 = -1;

            transform.localScale = Vector3.one;
        }


        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput1 = 1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) horizontalInput1 = 0;




        //jump
        if (Input.GetKey(KeyCode.W) && grounded)
            jump();

        //switching from idel to another animation 
        anim.SetBool("run", horizontalInput1 != 0);
        
    }

    private void jump()
    {
        body1.velocity = new Vector2(body1.velocity.x, speed);
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
        if(collision.gameObject.tag == "Door"){
            tp();
        }
    }
    private void die(bool iDie)
    {
        body1.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        player2.on1Death(iDie);
    }

    public void on2Death(bool sheDead)
    {
        if (sheDead)
            body1.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
    }

    private void restartlvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void tp(){

        if(player2.openDoorChecker2()){
            // SceneManager.LoadScene("Scene3");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
    public bool openDoorChecker1 (){
        return true;
    }
}

