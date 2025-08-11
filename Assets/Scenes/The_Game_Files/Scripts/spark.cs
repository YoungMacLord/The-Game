using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used to control movement of spark prefab
// also handles the destroy of the object
public class spark : MonoBehaviour
{
    // speed of spark
    public float speed;
    // Rigidbody of spark
    private Rigidbody2D rb;

    //[SerializeField]
    // private GameObject greenParticles;

    // Start is called before the first frame update
    void Start()
    {
        // get component rb and change velocity by speed variable
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        //rb.velocity = new Vector3(speed, 0.0f, 0.0f);

    }

    void Update()
    {
        // on update (each frame) if object is out of camera view
        // then destroy object
        if (transform.position.x < -17.0f || transform.position.x > 17.0f)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -10.0f || transform.position.y > 10.0f)
        {
            Destroy(gameObject);
        }

    }

    // on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Debug.Log(collision.GetComponent<Collider2D>().tag);
        // with player
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            // destroy object
            Destroy(gameObject);

            // damage to player is handled in another script

        }

    }
}