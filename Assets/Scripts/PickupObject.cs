using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    PlayerMovement player = new PlayerMovement();
    public AudioSource sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Item picked up");
            sound.Play();
            Destroy(gameObject);
        }
        else

            Debug.Log("Not working");
    }



}
