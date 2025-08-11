using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used for .wasPressedThisFrame
using UnityEngine.InputSystem;

// this class is used to select player weapon and shoot
public class shoot : MonoBehaviour
{

    // an int to pick weapon and a GameObject array of those weapons
    public int selectedWeapon;
    public GameObject[] Weapons;

    // Transforms from which weapons are shot from
    public Transform shootingPoint;
    public Transform bombPoint;

    // used for a weapon delay
    private float scatterTimeCounter;
    private float laserTimeCounter;
    public float scatterTime;
    public float laserTime;
    public bool laserCanShoot = true;
    public bool scatterCanShoot = true;

    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        shootDelay();

        // selects weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 2;
        }


        // this is the shooting control
        // if spacebar is pressed then instantiate selcted bullet. if bullet is scatter or 
        // laser than reset the delays and disallow shooting of object using the bool
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //instantiate spawns a clone of first argument bulletPrefab
            //shootingPoint is the position of spawn
            //Quaternion.identity is saying to spawn in rotation (0,0,0)
            if (selectedWeapon == 1)
            {
                Instantiate(Weapons[selectedWeapon], bombPoint.position, Quaternion.Euler(0, 0, 180));
            }
            else if (selectedWeapon == 2)
            {
                if (scatterCanShoot == true)
                {
                    bulletShoot();
                    scatterCanShoot = false;
                    scatterTimeCounter = 0;
                }
            }
            else
            {
                if (laserCanShoot == true)
                {
                    bulletShoot();
                    laserCanShoot = false;
                    laserTimeCounter = 0;
                }
            }

        }

    }


    // sets selected weapon to active
    void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in Weapons)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
        }
    }

    // called in update to create a delay for scatter and laser weapons
    void shootDelay()
    {
        if (scatterCanShoot == false)
        {
            scatterTimeCounter += Time.deltaTime;
            if (scatterTimeCounter >= scatterTime)
            {
                scatterCanShoot = true;
                scatterTimeCounter = scatterTime;
            }

        }
        if (laserCanShoot == false)
        {
            laserTimeCounter += Time.deltaTime;
            if (laserTimeCounter >= laserTime)
            {
                laserCanShoot = true;
                laserTimeCounter = laserTime;
            }

        }
    }

    // shoot function, creates a bullet object depending on selected weapon
    void bulletShoot()
    {
        Instantiate(Weapons[selectedWeapon], shootingPoint.position, Quaternion.identity);
    }
}