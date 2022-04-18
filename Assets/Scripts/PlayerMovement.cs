using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;

    public LayerMask groundCheck;
    public bool isGrounded;
    public Transform feetPosition;
    public float checkRadius;


    public bool isJumping = false;

    public float jumpStartTime;
    public float jumpTime;

    public GameObject target;

    private Rigidbody2D rigidBody;
    public MovementManager manage;

    public GameObject panel;
    public GameObject wPanel;

    public AudioSource jumpSFX;
    public AudioSource deathSFX;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, groundCheck);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

        //Normal Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumping = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            jumpTime = jumpStartTime;
            jumpSFX.Play();
        }

        //Slime Jump
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            if (jumpTime > 0)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = true;
            }

        }

        //Release SPACE to reset bool
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.tag == "Obstacle")
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            deathSFX.Play();

        }

        if(collision.transform.tag == "Target")
        {
            AttemptTracker.instance.attempts = 0;
            Time.timeScale = 0;
            wPanel.SetActive(true);
        }
    }

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
