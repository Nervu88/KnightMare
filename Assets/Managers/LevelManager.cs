using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject escapeMenues;
    private int escCount = 0;

    void Start()
    {
        escapeMenues.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escCount == 0)
        {
            setPause();
            escapeMenues.SetActive(true);
            escCount = 1;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && escCount == 1)
        {
            setContinue();
            escapeMenues.SetActive(false);
            escCount = 0;
        }
    }

    public void setPause()
    {
            Time.timeScale = 0;
    }
    public void setContinue()
    {  
            Time.timeScale = 1;  
    }

}
