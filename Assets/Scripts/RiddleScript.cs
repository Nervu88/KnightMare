using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddleScript : MonoBehaviour
{
  

    void Awake()
    {
        
    }

    LevelManager mgr = new LevelManager();
    Animator otherAnimator;
    public int riddleAnswer;
    public Text riddleBoxText;
    public GameObject riddleBox;
    public GameObject inputBox;
  //  public Text inputText;
    public int playerAnswer;

    public void OnTriggerEnter2D(Collider2D collision) // TÄSSÄ ON JOTAIN VIKAA VIELÄ PITÄÄ KORJATA!!! HUOMHUOM!!
    {

         /// KORJAUKSEN LOPPU
        if (collision.gameObject.tag == "Riddle")
        {

            riddleBox.SetActive(true);
            riddleBoxText.text = "";

            RandomRiddle theRiddle = collision.gameObject.GetComponent<RandomRiddle>();
            riddleBoxText.text = "Riddle is: What is the sum of " + theRiddle.firstNumber + " and " + theRiddle.secondNumber + " ( " + theRiddle.firstNumber + "+" + theRiddle.secondNumber + " =  ?) ";
            Debug.Log("Riddlen vastaus on " + theRiddle.riddleAnswer);
        }
        else
        {
            Debug.Log("Ei toimi!");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Riddle")
        {
            riddleBox.SetActive(false);
            riddleBoxText.text = "";
        }
        else
        {
        }
    }

}
