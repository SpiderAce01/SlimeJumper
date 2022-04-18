using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;

    public bool isJumping;

    public float jumpStartTime;
    public float jumpTime;

    public GameObject target;

    private Rigidbody2D rigidBody;
    public MovementManager manage;

    public GameObject panel;
    public GameObject wPanel;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            jumpTime = jumpStartTime; //Slime Jump
            isJumping = false;
        }

        //Slime Jump
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            if(jumpTime > 0)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = true;
            }
                        
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("enter");
        if (collision.transform.tag == "Ground")
        {
            isJumping = false;
        }

        if(collision.transform.tag == "Obstacle")
        {
            Time.timeScale = 0;
            panel.SetActive(true);
        }

        if(collision.transform.tag == "Target")
        {
            AttemptTracker.instance.attempts = 0;
            Time.timeScale = 0;
            wPanel.SetActive(true);
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    print("exit");
    //    if (collision.transform.tag == "Ground")
    //    {
    //        isJumping = true;
    //    }
    //}

    public void Restart()
    {
        AttemptTracker.instance.attempts++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
