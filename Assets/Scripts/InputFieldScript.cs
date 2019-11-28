using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{
    RiddleScript rld = new RiddleScript();
    RandomRiddle door = new RandomRiddle();
    LevelManager mgr = new LevelManager();
    public InputField mainInputField;
    public int playerAnswer;
    Animator anim = new Animator();


    public void SubmitAnswer()
    {
        playerAnswer = int.Parse(mainInputField.text);
        if (door.riddleAnswer == playerAnswer)
        {
            anim = door.GetComponent<Animator>();
            anim.SetTrigger("OpenDoor");
            door.gameObject.tag = "OpenDoor";
            Debug.Log("Vastasit Oikein");
            rld.inputBox.SetActive(false);
            mgr.setContinue();
        }
    }
}
