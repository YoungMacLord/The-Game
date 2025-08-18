using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles starting the game by loading the next scene
/// in the Build Settings order.
/// </summary>
public class startGame : MonoBehaviour
{
    /// <summary>
    /// Loads the next scene in the Build Setting sequence.
    /// </summary>
    public void LoadNewScene()
    {
        // Loads the scene one index ahead of the current active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}