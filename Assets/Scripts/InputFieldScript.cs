using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{
    LevelManager mgr = new LevelManager();
    public InputField mainInputField;
    public int playerAnswer;

    public void Start()
    {

    }

    public int ReturnAnswer()
    {
        playerAnswer = int.Parse(mainInputField.text);
        mgr.setContinue();
        return playerAnswer;
    }

}
