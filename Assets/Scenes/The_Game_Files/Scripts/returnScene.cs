using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this script is used on the help screen to return to the main menu
// scenes are in a numbered order
public class returnScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        // if backspace key is pressed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
            // load the previous scene (the main menu)
        }
    }
}
