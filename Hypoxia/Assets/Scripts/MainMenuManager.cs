using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame() //Guzik start game aktywuje to
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenSettings() //Guzik settings aktywuje to
    {
        
        Debug.Log("Open Settings");
    }

    public void QuitGame() //Guzik exit game aktywuje to
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
