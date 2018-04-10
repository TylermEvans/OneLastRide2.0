using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed; // speed of the player
    public int health; // the players health
    //public Bullet[] bullets;
    public float bulletCooldown; // the bullet fire rate
    private float oldTime; // the max bullet fire rate
    public GameObject weapon;
    public Bullet bullet;


    private void Start()
    {
        oldTime = bulletCooldown; // save off the maxval for later
        weapon = null;
    }
    private void FixedUpdate()
    {
        
        Rigidbody playerRigidbody = GetComponent<Rigidbody>(); // get rigibody physics comp
        float horizontalMove = Input.GetAxis("Horizontal"); // get player left jostick/directional key input
        float verticalMove = Input.GetAxis("Vertical"); 
        Vector3 newVel = new Vector3(horizontalMove, 0.0f, verticalMove); 
        playerRigidbody.velocity = newVel * speed * Time.fixedDeltaTime; // set new velocity to be the one from input * speed value scaled by deltatime
        Vector3 newDir = new Vector3(Input.GetAxis("Rhorizontal"), 0.0f, Input.GetAxis("Rvertical"));
        if (newDir != Vector3.zero)
        {
            playerRigidbody.rotation = Quaternion.LookRotation(newDir * Time.fixedDeltaTime);      // set players orientation == direction of second analog stick/axis

        }
        

        /*for(int b = 0; b < bullets.Length; b++) {
            bullets[b].update(this);
        }*/
    }

    public void powerUpPickUp(WeaponBaseClass wi) {
        // should be called on collision with a power up
        // changes weapon associated with player

        // ...

        // if the pickup is able to timeout, then we should reset bullet somehow
        // but im not concerned with that rn
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            weapon = other.gameObject;
         
        }
    }

}
