using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public int Health;
    public GameObject bullet;

    private void FixedUpdate()
    {
        Rigidbody playerRigidbody = GetComponent<Rigidbody>(); // get rigibody physics comp
        float horizontalMove = Input.GetAxis("Horizontal"); // get player left jostick/directional key input
        float verticalMove = Input.GetAxis("Vertical"); 
        Vector3 newVel = new Vector3(horizontalMove, 0.0f, verticalMove); 
        playerRigidbody.velocity = newVel * speed * Time.fixedDeltaTime; // set new velocity to be the one from input * speed value scaled by deltatime
        Vector3 newDir = new Vector3(Input.GetAxis("Rhorizontal"), 0.0f, Input.GetAxis("Rvertical"));
        playerRigidbody.rotation = Quaternion.LookRotation(newDir * Time.fixedDeltaTime);      // set players orientation == direction of second analog stick/axis8

        float attack = Input.GetAxis("PrimaryAttack");
        Vector3 newpos = transform.position + transform.forward * 2;
        if (attack != 0)
        {
            Instantiate(bullet, newpos, Quaternion.LookRotation(transform.forward));
        }
    }

}
