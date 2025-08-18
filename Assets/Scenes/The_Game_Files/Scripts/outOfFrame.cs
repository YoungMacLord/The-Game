using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys the object when it moves too far off the left side of the screen.
/// Useful for cleaning up projectiles, enemies, or obstacles that leave the play area.
/// </summary>
public class outOfFrame : MonoBehaviour
{
    /// <summary>
    /// Update is called once per frame
    /// Checks the object's position and destroys it if it goes past the boundary.
    /// </sumamry>
    void Update()
    {
        // If the object moves too far left, remove it from the scene.
        if (transform.position.x < -17.0f)
        {
            Destroy(gameObject);
        }
    }
}
