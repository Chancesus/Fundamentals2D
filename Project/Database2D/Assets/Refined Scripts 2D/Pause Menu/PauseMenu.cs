using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    //Hold Pause Canvas, need to set up Canvas and buttons in Unity
    [SerializeField] Canvas pauseCanvas;
    
    void Update()
    {
        //Check if Player pressed ESC to pause game
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        //Turn on Pause Menu and Set time to 0
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        //Turn off Pause Menu and set time to 1(unpaused)
       Time.timeScale = 1f;
        pauseCanvas.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        //Exit level 1 and load Main Menu
        SceneManager.LoadScene("MainMenu");
    }


}
