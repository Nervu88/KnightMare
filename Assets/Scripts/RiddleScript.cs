using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleScript : MonoBehaviour
{
  

    void Awake()
    {
        
    }
    RandomRiddle rldDoor = new RandomRiddle();
    LevelManager mgr = new LevelManager();
    Animator otherAnimator;
    public int riddleAnswer;
    public Text riddleBoxText;
    public GameObject riddleBox;
    public GameObject inputBox;
    public InputField inputField;
    public Text txtCorrect;
    public int playerAnswer;
    GameObject Door;
    GameObject theRiddleObj;

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "DoorClosed")
        {
            inputBox.SetActive(true);
            mgr.setPause();
            Door = collision.gameObject;
            otherAnimator = collision.gameObject.GetComponent<Animator>();
        }

        else if (collision.gameObject.tag == "Riddle")
        {

            riddleBox.SetActive(true);
            riddleBoxText.text = "";

            RandomRiddle theRiddle = collision.gameObject.GetComponent<RandomRiddle>();
            theRiddleObj = collision.gameObject;
            riddleBoxText.text = "Riddle is: What is the sum of " + theRiddle.firstNumber + " and " + theRiddle.secondNumber + " ( " + theRiddle.firstNumber + "+" + theRiddle.secondNumber + " =  ?) ";
            Debug.Log("Riddlen vastaus on " + theRiddle.riddleAnswer);
            riddleAnswer = theRiddle.riddleAnswer;
            
        }
        else
        {
            Debug.Log("Ei toimi!");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "DoorClosed" || collision.gameObject.tag == "DoorOpen")
        {
            txtCorrect.text = "";
        }
        if (collision.gameObject.tag == "Riddle")
        {
            riddleBox.SetActive(false);
            riddleBoxText.text = "";
            txtCorrect.text = "";
        }
        else
        {
        }
    }

    public void ButtonPressed()
    {
        playerAnswer = int.Parse(inputField.text);
        Debug.Log(playerAnswer);

        if (playerAnswer == riddleAnswer)
        {    
            otherAnimator.SetTrigger("OpenDoor");
            Door.gameObject.tag = "DoorOpen";
            AudioSource audion = Door.GetComponent<AudioSource>();
            audion.Play();
            Destroy(theRiddleObj);
            inputBox.SetActive(false);
            txtCorrect.text = "CORRECT!";
            mgr.setContinue();
            riddleAnswer = 0;
        }
        else
        {
            txtCorrect.text = "INCORRECT! Try again!";
            inputBox.SetActive(false);
            mgr.setContinue();
        }
    }

}
