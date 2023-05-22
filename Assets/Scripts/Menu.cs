using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    public Button menuButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            startButton.onClick.AddListener(StartGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        if (SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Lose")
        {
            menuButton.onClick.AddListener(menu);
        }
    }

    // Update is called once per frame
    void Update()
    {

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

    public void menu()
    {

        SceneManager.LoadScene("Menu");

    }




}
