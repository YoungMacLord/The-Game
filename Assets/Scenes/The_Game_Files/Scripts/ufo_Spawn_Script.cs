using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles spawning UFOs at a given position and interval,
/// with an initial delay before the first spawn.
/// Ensures only one UFO exists in the scene at a time.
/// </summary>
public class ufo_Spawn_Script : MonoBehaviour
{
    /// <summary>
    /// UFO prefab to spawn.
    /// </summary>
    public GameObject ufo;

    /// <summary>
    /// UFO prefab to spawn.
    /// </summary>
    private GameObject spawnedObject;

    /// <summary>
    /// Whether a UFO can currently be spawned.
    /// </summary>
    public bool canSpawn = false;

    /// <summary>
    /// Minimum time between UFO spawns.
    /// </summary>
    public float spawnInterval = 0.5f;

    /// <summary>
    /// Initial delay before the first UFO spawn.
    /// </summary>
    public float spawnDelay = 2.0f;

    /// <summary>
    /// Timer tracking time since last spawn.
    /// </summary>
    public float spawnTimer = 0f;

    /// <summary>
    /// Timer tracking time since script started (used for initial delay).
    /// </summary>
    public float delayTimer = 0f;
    
    /// <summary>
    /// Called once per frame.
    /// Handles UFO spawn logic, timers, and ensures only one UFO exists.
    /// </summary>
    void Update()
    {
        //timer = timer + Time.deltaTime;
        // Allow spawning if no UFO is currently spawned in the scene
        if (spawnedObject == null && GameObject.Find("MAMA_SPACESHIP(Clone)") == null)
        {
            canSpawn = true;
        }
        else {
            canSpawn = false;
        }

        // If spawning is allowed, check timers
        if (canSpawn)
        {
            // Wait until the initial spawn delay has passed
            if (delayTimer >= spawnDelay)
            {
                // Once the interval is reached, spawn a UFO
                if (spawnTimer >= spawnInterval)
                {
                    spawnUfo();
                    // Reset timer after spawning
                    spawnTimer = 0;
                }
                else
                {
                    // Count up until next spawn
                    spawnTimer += Time.deltaTime;
                }
            }
            else
            {
                // Count up until initial delay is complete
                delayTimer += Time.deltaTime;
            }

        }
    }

    /// <summary>
    /// Spawns a UFO prefab at this object's position.
    /// </summary>
    void spawnUfo()
    {
        spawnedObject = Instantiate(ufo, new Vector3(transform.position.x, transform.position.y, 0.0f), transform.rotation);
        canSpawn = false; // Prevent immediate re-spawn
    }
}
