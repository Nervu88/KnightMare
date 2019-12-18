using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Scene currentScene;
    SceneManager scene = new SceneManager();
    public float moveSpeed = 5f;
    private float velocityValue;
    public Animator thisAnim;
    public Rigidbody2D rb;
    public int count;
    public Text countText;
    public Text winText;
    public int scoreToWin;
    public AudioClip victorySound;
    public AudioClip collect;
    AudioSource source;
    Vector2 movement;
    Vector2 velocity;
    private IEnumerator coroutine;
    

    void Start()
    {
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        source = GetComponent<AudioSource>();
        thisAnim = GetComponentInChildren<Animator>();
        count = 0;
        winText.text = "";

        SetCountText();
    }

    void Update()
    {
        // Input hommat

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        velocityValue = movement.x + movement.y;
    }

    void FixedUpdate()
    {
        // Movement jutut

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Animaation käytös 0 = idleAnim -1 +1 on isMoving

        if (velocityValue > 0)
        {
            thisAnim.SetFloat("Velocity", 1);

        } else if (velocityValue < 0)
        {
            thisAnim.SetFloat("Velocity", 1);
        } else
        {
            thisAnim.SetFloat("Velocity", 0);
        }


    }
    // Collectibles count laskin
    void SetCountText()
    {
        int buildIndex = currentScene.buildIndex;
        countText.text = count.ToString();

        if (count >= scoreToWin)
        {
            source.volume = 0.1f;
            source.PlayOneShot(victorySound);
            switch (buildIndex)
            {
                case 1:
                    winText.text = "You found all the collectibles. Congratulations! Loading next level...";
                    coroutine = NextLeveli(10.0f);
                    StartCoroutine(coroutine);
                    break;
                case 2:
                    winText.text = "You found all the collectibles. Congratulations! \n The game will close in 10 secs...";
                    coroutine = AppClose(10.0f);
                    StartCoroutine(coroutine);
                    break;
            }
        }
    }
    //--------------- Pelin automaattinen Quit ----------------------
    private IEnumerator AppClose(float time) 
    {
            yield return new WaitForSeconds(time);
            Debug.Log("Toimii");
            scene.MainMenu();
    }
    private IEnumerator NextLeveli(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Toimii");
        scene.NextLevel();
    }


    //--------------- Collisionin koodi ----------------------
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            source.volume = 0.4f; 
            source.PlayOneShot(collect);
            count++;
            Debug.Log("Item picked up");
            SetCountText();        
            Destroy(other.gameObject);
        }
    }
}

