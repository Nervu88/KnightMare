using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject escapeMenues;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleMenu();
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

    public void toggleMenu()
    {
        if (escapeMenues.activeInHierarchy)
        {
            escapeMenues.SetActive(false);
           setContinue();

        } else
        {
            escapeMenues.SetActive(true);
           setPause();
        }
    }
}

