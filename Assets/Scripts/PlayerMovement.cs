using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    SceneManager Scene;
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

    

    void Start()
    {
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

        countText.text = count.ToString();
        
        if (count >= scoreToWin)
        {
            
            source.volume = 0.1f;
            source.PlayOneShot(victorySound);
            winText.text = "You collected all the Beer and Coins! CONGRATS \n The game will close in 10 secs...";   
            StartCoroutine("AppClose");
        }
    }
    //--------------- Pelin automaattinen Quit ----------------------
    private IEnumerator AppClose()
    {
            yield return new WaitForSeconds(10f);
            Debug.Log("Toimii");
            Scene.ExitThis();
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
        else

            Debug.Log("Not working");
    }

}
