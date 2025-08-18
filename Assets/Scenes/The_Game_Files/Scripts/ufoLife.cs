using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls UFO health, destruction, and score logic.
/// UFOs only become destructible after passing a threshold on the X-axis.
/// </summary>
public class ufoLife : MonoBehaviour
{
    //private Rigidbody2D ufoRB;
    //public GameObject player;

    /// <summary>
    /// The total healt points of the UFO
    /// </summary>
    public int life;
    bool canBeDestroyed = false;

    /// <summary>
    /// The number of points awarded wehn this UFO is destroyed.
    /// </summary>
    public int scoreValue = 300;
    public logicScript logic;

    /// <summary>
    /// Finds the game logic script by tag on start.
    /// </summary>    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();

    }

    /// <summary>
    /// Makes UFO destructible once it passes a certain x-position.
    /// </summary>    
    void Update()
    {
        if (transform.position.x < 15.0f)
        {
            canBeDestroyed = true;
        }
    }

    /// <summary>
    /// Handles collisions with bullets and other destructible objects.
    /// </summary>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;

        }

        if (collision.GetComponent<Collider2D>().tag == "plBullet")
        {
            life -= 1;
            if (life == 0)
            {
                Destroy(gameObject);
                logic.GetComponent<logicScript>().AddScore(scoreValue);
            }
        }

        // Check if the collided object has one of the destructible components
        Bullet bullet = collision.GetComponent<Bullet>();
        ExplosionScript eScript = collision.GetComponent<ExplosionScript>();
        scatterScript s_script = collision.GetComponent<scatterScript>();

        // If it's a Bullet, destroy it immediately
        if (bullet != null)
        {
            Destroy(bullet.gameObject);
        }

        // If it's an ExplosionScript, destroy it after a short delay to allow animation/effect
        if (eScript != null)
        {
            Destroy(eScript.gameObject, 0.5f);   
        }

        // If it's a ScatterScript (like secondary projectiles), destroy it immediately
        if (s_script != null)
        {
            Destroy(s_script.gameObject);
        }

        if (life == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
