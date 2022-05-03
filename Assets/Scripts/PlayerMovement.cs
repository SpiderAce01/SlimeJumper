using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject pausePanel;

    public AudioSource jumpSFX;
    public AudioSource deathSFX;
    public AudioSource coinSFX;
    public AudioSource victorySFX;

    [SerializeField] private SkinManager skinManager;
    [SerializeField] private TMP_Text coinsText;
    private int count;
    private int coinCount = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
        count = PlayerPrefs.GetInt("Coins");
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

        coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.transform.tag == "Obstacle")
        {
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Coins", count - coinCount);
            panel.SetActive(true);
            deathSFX.Play();

        }

        if(collision.transform.tag == "Target")
        {
            Time.timeScale = 0;
            wPanel.SetActive(true);
            victorySFX.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            count += 1;
            coinCount += 1;
            coinSFX.Play();
            PlayerPrefs.SetInt("Coins", count);
        }
    }

    public void Play()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        if(wPanel.active == true)
        {
            AttemptTracker.instance.attempts = 1;
        }
        else
        {
            AttemptTracker.instance.attempts++;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        AttemptTracker.instance.attempts = 1;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
