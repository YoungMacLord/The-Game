using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls UFO movement in the scene. 
/// Moves the UFO horizontally and vertically with boundaries and wraps around if needed.
/// </summary>
public class UfoMovement : MonoBehaviour
{
    //public GameObject ufo;

    /// <summary>
    /// Speed at which the UFO moves along the X-axis.
    /// </summary>
    public float moveSpeedx = 5;

    /// <summary>
    /// Speed at which the UFO moves along the Y-axis.
    /// </summary>
    public float moveSpeedy = 5;
    //public float spawnRate = 2f;
    //private float timer = 0f;
    //public float heightOffset = 8.5f;
    //public bool canSpawn = false;

    /// <summary>
    /// Called once per frame.
    /// Currently not used; commented-out logic for potential spawn timing.
    /// </summary>    
    /// void Update()
    {
        /*
        if (canSpawn)
        {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnUfo();
                timer = 0f;
            }
        }
        */
    }

    /// <summary>
    /// Called at fixed intervals, used for physics-related movement.
    /// Moves UFO horizontally and vertically, with boundary checks.
    /// </summary>
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        // Move left if the UFO is past the right boundary
        if (pos.x > 14)
        {
            pos.x -= moveSpeedx * Time.fixedDeltaTime;
        }
        // If UFO is past left threshold, handle vertical movement
        if (pos.x < 14)
        {
            // Wrap vertically if it goes too high
            if (pos.y > 11)
            {
                pos.y = -11;
            }

            // Apply the updated position
            pos.y += .08f;
        }


        transform.position = pos;
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if(bullet!= null)
        {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
        }
        Destructable destructable = collision.GetComponent<Destructable>();


    }
    */

}
