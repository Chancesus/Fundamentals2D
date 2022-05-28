using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelSelect : MonoBehaviour
{
    /*In order for script to work you need to set up buttons and a panel
     * then use onclick events attached to buttons
     */

    //List to hold strings of levels
    [SerializeField] List<string> levelToLoad;

    //Method to Start level 1
    public void StartGame()
    {
        SceneManager.LoadScene("BoxScene");
    }
    //Method to Access list of levels using different buttons
    public void LoadLevel(int listindex)
    {
        SceneManager.LoadScene(levelToLoad[listindex]);
    }

}
