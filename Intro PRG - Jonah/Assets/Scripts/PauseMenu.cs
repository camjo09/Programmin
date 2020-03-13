using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausePanel;
    public GameObject optionsPanel;
    void Start()
    {
        //our game to run
        Time.timeScale = 1;
        //cursor locked to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //hide our cursor 
        Cursor.visible = false;
        //Set the bool to false
        isPaused = false;
        //hide pause panel
       // pausePanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!optionsPanel.activeSelf)
            {
                TogglePause();
            }
            else 
            {
                pausePanel.SetActive(true);
                optionsPanel.SetActive(false);
            }
        }
    }
    public void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log(isPaused);
        if (isPaused)
        {
            //turn off time
            Time.timeScale = 0;
            //allow cursor movement
            Cursor.lockState = CursorLockMode.None;
            //show cursor
            Cursor.visible = true;
            //show pause panel
            pausePanel.SetActive(true);
        }
        else
        {
            //turn on time
            Time.timeScale = 1;
            //stop cursor movement
            Cursor.lockState = CursorLockMode.Locked;
            //hide cursor
            Cursor.visible = false;
            //hide pause panel
            pausePanel.SetActive(false);
        }
    }
}
