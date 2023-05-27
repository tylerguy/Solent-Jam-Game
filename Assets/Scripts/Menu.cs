using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            startButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
        }

    }
    // if start game button is pressed, load the game scene
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // if quit game button is pressed, quit the game
    public void QuitGame()
    {
        Application.Quit();

    }
}
