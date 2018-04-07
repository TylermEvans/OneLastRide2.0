using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed; // speed of the player
    public int Health; // the players health
    public Bullet[] bullets;
    public float bulletCooldown; // the bullet fire rate
    private float oldTime; // the max bullet fire rate
    public WeaponBaseClass weapon;


    private void Start()
    {
        oldTime = bulletCooldown; // save off the maxval for later
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
        float attack = Input.GetAxis("PrimaryAttack");
        Vector3 newpos = transform.position + transform.forward * 1;
        bulletCooldown -= Time.fixedDeltaTime; // bullet countdown
        if ((attack != 0 || Input.GetKeyDown("space")) && bulletCooldown <= 0) // attack with space bar or right trigger on gamepad
        {
            if (transform.forward != Vector3.zero)
            {
                //Instantiate(bullet, newpos, Quaternion.LookRotation(transform.forward)); // create bullet
                bulletCooldown = oldTime; // reset bullet cooldown
            }
            
        }

        for(int b = 0; b < bullets.Length; b++) {
            bullets[b].update(this);
        }
    }

    public void powerUpPickUp(WeaponBaseClass wi) {
        // should be called on collision with a power up
        // changes bullet associated with player

        /*
        this.bullet.speed = p.speed;
        this.bullet.damage = p.damage;
        // modify bullet pattern here
        */
        // if the pickup is able to timeout, then we should reset bullet somehow
        // but im not concerned with that rn
    }

}
