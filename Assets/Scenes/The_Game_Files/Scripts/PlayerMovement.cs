using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player movement using keyboard input, 
/// applies movement speed, and enforces screen boundaries.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    // Speed multiplier for player movement.
    [SerializeField] private float speed;

    // Reference to the Rigidbody2D component for movement physics.
    private Rigidbody2D body;

    // Horizontal movement limit (player cannot most past this X boundary)
    public float xBorder;

    // Vertical movement limit (player cannot move past this Y boudnary)
    public float yBorder;

    /// <summary>
    /// Called before Start. Caches references needed for movement.
    /// </summary>
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Called once per frame. Handles player input and enforces movement boundaries.
    /// </summary> 
    private void Update()
    {
        // Apply velocity based on ipnut axes (WASD / Arrow keys by default)
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        // Get current position
        Vector2 pos = transform.position;

        // Clamp X position within left/right boundaries
        if (pos.x <= -xBorder)
        {
            pos.x = -xBorder;
        }
        if (pos.x >= xBorder)
        {
            pos.x = xBorder;
        }

        // Clamp Y position within bottom/top boundaries
        if (pos.y <= -yBorder)
        {
            pos.y = -yBorder;
        }
        if (pos.y >= yBorder)
        {
            pos.y = yBorder;
        }

        // Apply corrected position
        transform.position = pos;
    }
}
