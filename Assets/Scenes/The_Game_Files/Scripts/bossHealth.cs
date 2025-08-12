using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles the in game Boss's health 
// and score behavior

public class bossHealth : MonoBehaviour
{

    //holds variables for the boss's health and spawn 

    public int life;
    bool canBeDestroyed = false;
    public int scoreValue = 5000;
    public logicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // finds the games logic script
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        // handles the boss's spawn 
        // switches canBe destroyed to true because the 
        // default is false 

        if (transform.position.x < 15.0f)
        {
            canBeDestroyed = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;

        }

        //handles the boss's health when getting hit by a player's weapon
        //life is decrease by 1
        //adds the corresponding score to the player's score 
        //once the boss is defeated
        if (collision.GetComponent<Collider2D>().tag == "plBullet")
        {
            life -= 1;
            if (life == 0)
            {
                Destroy(gameObject);
                logic.GetComponent<logicScript>().AddScore(scoreValue);
            }
        }

        Bullet bullet = collision.GetComponent<Bullet>();
        ExplosionScript eScript = collision.GetComponent<ExplosionScript>();
        scatterScript s_script = collision.GetComponent<scatterScript>();

        if (bullet != null)
        {
            Destroy(bullet.gameObject);
        }
        if (eScript != null)
        {
            Destroy(eScript.gameObject, 0.5f);
        }
        if (s_script != null)
        {
            Destroy(s_script.gameObject);
        }

        // destroys the game object when the boss's health is at 0
        if (life == 0)
        {
            Destroy(gameObject);
        }

    }

    // resets the Boss's spawn value so it can spawn later
    void OnDestroy()
    {
        logic.GetComponent<logicScript>().spawnNumber = 0;
    }
}
