using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// the name of this script is actually misleading:
// this script is used for the spawing of both straight flyers and sin flyers
// of fly guy enemies.
public class straightSpawnScript : MonoBehaviour
{

    // object fly_guy_group is either a grop of straight flyers or sin flyers
    public GameObject fly_guy_group;
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 8.5f;
    // boolean to control if fly guys can spawn or not
    public bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {

        //canSpawn = true;
        //boss = GameObject.Find("MAMA_SPACESHIP").GetComponent<bossHealth>();
        //m_Renderer = boss.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // if boss battle turn off spawner. boss has it's own fly guy spawner
        if (GameObject.Find("MAMA_SPACESHIP(Clone)") != null)
        {
            canSpawn = false;
        }
        else canSpawn = true;

        if (canSpawn)
        {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnFlyGuy();
                timer = 0f;
            }
        }
    }

    void spawnFlyGuy()
    {
        // range of which fly guys can spawn based on spawn point and camera view
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // spawn
        Instantiate(fly_guy_group, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0.0f), transform.rotation);
    }
}