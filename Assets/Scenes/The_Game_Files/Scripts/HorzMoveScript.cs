using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles horizontal movement of an object (both enemies and obstacles)
/// Moves left at a constant speed and destroys the object once it goes off-screen
/// </summary>
public class HorzMoveScript : MonoBehaviour
{
    // Speed at which the object moves along the X-axis
    public float moveSpeed = 5;

    // Called at fixed intervals rather than once per frame (unlike the Update() method)
    private void FixedUpdate()
    {
        // Get current position 
        Vector2 pos = transform.position;

        // Move left by moveSpeed, scaled by frame time
        pos.x -= moveSpeed * Time.fixedDeltaTime;

        // Destroy the object if it moves past the left boundary
        if (pos.x < -18)
        {
            // Removes the object from the visible screen
            Destroy(gameObject);
        }
        
        // Apply updated position back to the transformation
        transform.position = pos;
    }
}
