using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

/// <summary>
/// Manages player health, UI hearts, invicibility frames, and death handling.
/// </sumamry>
public class Life : MonoBehaviour
{
    // Reference to the player's Rigidbody2D
    private Rigidbody2D shipRB;
    
    // Current number of lives the player has
    public int life = 3;

    // Whether the player is currently invicible after taking damage
    private bool isInvincible = false;

    // Duration of invincibility in seconds 
    public float invincibilityDurationSeconds;

    // Time between flashes while invincible
    public float invincibilityDeltaTime;

    // General purpose timer (not currently used)
    public float timer;

    /// UI images representing the player's lives (as hearts)
    public Image playerHeart, playerHeart_1, playerHeart_2;

    // text displayed when the player dies
    public Text deathText;

    public AudioSource source1, source2;     // source1 = hurt player, source2 = player death
    [SerializeField]
    private GameObject model;


    // Start is called before the first frame update
    void Start()
    {
        deathText.enabled = false; // Hides death text at the start
        shipRB = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handles collisions with pickups, enemies, and bullets
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //UnityEngine.Debug.Log("Collision!");
        // If collision is with a health pickup
        if (collision.GetComponent<Collider2D>().tag == "pickUp")
        {
            //dropHealth healthPack = collision.GetComponent<dropHealth>();

            if (life != 3) // Only heal if not already at max health
            {
                life += 1;
                if (life == 3)
                {
                    playerHeart_2.enabled = true;
                }
                if (life == 2)
                {
                    playerHeart_1.enabled = true;
                }

            }

            // Removes picked-up object from the visible screen
            Destroy(collision.gameObject);

        }

        // Ignores collisions while invincible 
        if (isInvincible) return;

        // If hit by enemy or bullet
        if (collision.GetComponent<Collider2D>().tag == "Enemy" || collision.GetComponent<Collider2D>().tag == "Bullet")
        {
            // Play the hurt sound effect
            source1.Play();
            life -= 1;

            // Update UI hearts based on remaining lives
            if (life == 2)
            {
                playerHeart_2.enabled = !playerHeart_2.enabled;
            }
            if (life == 1)
            {
                playerHeart_1.enabled = !playerHeart_1;
            }
            if (life == 0)
            {
                playerHeart.enabled = !playerHeart;

                //Player is destroyed when lives runs out 
                Destroy(gameObject);
            }

            // Start the invincibility coroutine
            StartCoroutine(BecomeTemporarilyInvincible());
        }
       
    }

    /// <summary>
    /// Makes the player invincible for a set duration and flashes to indicate current state
    private IEnumerator BecomeTemporarilyInvincible()
    {
        //UnityEngine.Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            
            if (model.transform.localScale == Vector3.one)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(Vector3.one);
            }
            
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        //Debug.Log("Player is no longer invincible!");
        // Reset state after invincibility ends
        ScaleModelTo(Vector3.one);
        isInvincible = false;
    }

    /// <summary>
    /// Scales the player model to the given value (used for flashing)
    /// </summary>
    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }

    /// <summary>
    /// Called when the player object is destroyed.
    /// Displayed the death text on screen.
    /// </summary>
    void OnDestroy()
    {
        deathText.enabled = true;
    }


}
