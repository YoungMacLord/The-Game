using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a class used to control sin movement of spawned fly guys
public class SinMove : MonoBehaviour
{
    // floats for control of sin pattern
    float sinCenter;
    public float amplitude;
    public float frequency;

    //
    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        sinCenter = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // change x and y based on sin wave
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;

        // flip if inverted
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenter + sin;

        transform.position = pos;
    }
}
