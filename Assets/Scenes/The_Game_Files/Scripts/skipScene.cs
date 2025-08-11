using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// used on the intro text scene to get to the game scene
public class skipScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if space is pressed go to next scene
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
