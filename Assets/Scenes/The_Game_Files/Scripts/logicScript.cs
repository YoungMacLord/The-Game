using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this script is used for handling logic for player score and an int
// spawnNumber which is used for spawning the boss. In retrospect there's
// no need for two separate variables but I'm not changing it  right now
// for fear of breaking the game

// the Destructable.cs and bossSpawnScript.cs have access to this script

public class logicScript : MonoBehaviour
{
    public static int playerScore = 0;
    public Text scoreText;
    public int spawnNumber = 0;
    //public Image playerHeart, playerHeart_1, playerHeart_2;

    //public static logicScript instance;

    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GameObject.Find("scoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // the main thing here is this function which adds amounts based on what
    // enemy was destroyed.

    public void AddScore(int amount)
    {
        spawnNumber += amount;
        playerScore += amount;
        scoreText.text = playerScore.ToString();
    }
}