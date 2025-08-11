using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used to control the velocities of 
// each star in the scatter shot weapon

public class scatterScript : MonoBehaviour
{
    // floats x and y are velocities
    // these have been tweaked in unity and are different for
    // each star so that they move forward and spread apart
    // rb is the Rigidbody2D of the star
    public float x;
    public float y;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // get component ridigbody
        rb.velocity = new Vector3(x, y, 0.0f);
        // move rigidbody by velocity

    }

    // Update is called once per frame
    // destroy if star goes out of frame
    void Update()
    {
        if (transform.position.x < -17.0f || transform.position.x > 17.0f)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -10.0f || transform.position.y > 10.0f)
        {
            Destroy(gameObject);
        }

    }
    // there is also logic to destroy star if it hits an enemy and there is logic
    // to destroy the scatter parent object if all stars are destroyed
}
