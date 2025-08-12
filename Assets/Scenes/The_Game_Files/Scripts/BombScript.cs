using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the player's Bomb weapon behavior


public class BombScript : MonoBehaviour
{
    //public float speed;
    private Rigidbody2D BombRB;
    public GameObject explosion;
    public Transform ExplosionPoint;


    // Start is called before the first frame update

    void Start()
    {
        //the BombRB variable holds the collider for every bomb that is instantiated
        BombRB = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(speed, 0.0f, 0.0f);

    }

    void Update()
    {
        //pos holds the position of the bomb in the scene
        //the if statement handles the deletion of the bomb 
        // if the bomb is detected out of bounds


        Vector2 pos = transform.position;
        if (pos.y < -12)
        {
            Destroy(gameObject);
        }

        //rb.velocity = new Vector3(speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.Log(collision.GetComponent<Collider2D>().tag);

        //This part of the code detects collision with an enemy in which
        //it will spawn in the explosion of the bomb at the position
        // of the collision 

        if (collision.GetComponent<Collider2D>().tag =="Enemy")
        {
            Instantiate(explosion, ExplosionPoint.position + new Vector3(0,0,-1), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}