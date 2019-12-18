using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomRiddle : MonoBehaviour
{

    public int firstNumber;
    public int secondNumber;
    public int riddleAnswer;
    public GameObject Door;

    void Start()
    {
        AddRiddle();
    }

    void Update()
    {
        
    }

    public void AddRiddle()
    {
        firstNumber = Random.Range(0, 100);
        secondNumber = Random.Range(1, 100);
        riddleAnswer = firstNumber + secondNumber;
        Door.GetComponent<RiddleAnswer>().riddleAnswer = riddleAnswer;
    }
}
