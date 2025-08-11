using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this script is used to return to the main menu from the highscore scene
// the scenes are in a numbered order

public class returnStart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        // if backspace is pressed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
            // retrun to 4 scenes prior (main menu)
        }
    }
}
