using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of a bullet, including movement and self-destrucition
/// when it leaves the visible play area
/// </summary>
public class Bullet : MonoBehaviour
{
    // Speed of the bullet along the x-axis of the scene
    public float speed;

    // Reference to the sprite's Rigidbody2D component 
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the Rigidbody2D attatched to this bullet
        rb = GetComponent<Rigidbody2D>();

        // Applies velocity so the bullet moves right on the x-axis
        rb.velocity = new Vector3(speed, 0.0f, 0.0f);

    }

    // Called once per frame
    void Update()
    {
        // Destroys the bullet if it goes too far left or right (off-screen)
        if (transform.position.x < -17.0f || transform.position.x > 17.0f)
        {
            // Removes the bullet from the scene
            Destroy(gameObject);
        }

    }


}
