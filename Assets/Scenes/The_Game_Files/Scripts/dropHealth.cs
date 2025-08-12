using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script handles the health pack spawns
//the rng for the spawns are initiated when 
//an enemy is killed

public class dropHealth : MonoBehaviour
{

    public int random, low, high;
    public GameObject healthPack;
    public Transform dropPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnDestroy()
    {
        random = Random.Range(low, high);
        if (random == 7)
        {
            Instantiate(healthPack, dropPoint.position, Quaternion.identity);
        }
    }

}
