using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script handles the explosion of the bombs
//desroys the explosion object after its duration

public class ExplosionScript : MonoBehaviour
{
    public float ExplosionDuration;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, ExplosionDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
