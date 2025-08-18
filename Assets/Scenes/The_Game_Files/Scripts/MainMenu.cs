using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles main menu button functionality for navigating between game scenes,
/// quitting the game, and loading help/highscore screens.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game by loading the main gameplay scene.
    /// </summary>
    public void PlayGame()
    {
        // Loads the scene two indexes ahead of the current one in Build Settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    /// <summary>
    /// Quits the game when the Quit button is clicked.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Loads the Help screen scene.
    /// </summary>
    public void helpScreen()
    {
        // Loads the scene one index ahead of the current one in Build Settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Loads the High Scores screen scene.
    /// </summary>
    public void highscoresScreen()
    {
        // Loads the scene four indexes ahead of the current one in Build Settings.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
}