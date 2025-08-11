using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is used to create a scrolling background effect of a
// quad. a quad is a primative 3d object used to represent flat surfaces like 
// walls and floors or in this case a background

public class ScrollingBackground : MonoBehaviour
{
    // speed is used to control the speed of the scrolling background effect
    public float speed;

    // SerializeField allows a private variable to be controlled by the inspector
    // this way the Unity has access to a Renderer bgRenderer and no other script 
    // can change it
    // in retrospect it seems a good practice would have been to make most variable private
    // and use serialize field unless the particular varible in question needs access from another
    // script. I will look into this more
    [SerializeField]
    // renderer is an object that visualizes things
    // a mesh filter quad and mesh renderer are used here
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        // on update offset the mesh by speed
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0); 
    }
}
