using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void PlayGame() //just load the main game
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()  //exit the game if this is played on pc
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
