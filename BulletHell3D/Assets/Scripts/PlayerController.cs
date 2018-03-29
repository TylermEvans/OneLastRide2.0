using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxis("Horizontal"); // get player left jostick/directional key input
        float verticalMove = Input.GetAxis("Vertical"); 
        Rigidbody playerRigidbody = GetComponent<Rigidbody>(); // get rigibody physics comp
        Vector3 newVel = new Vector3(horizontalMove, 0.0f, verticalMove); 
        playerRigidbody.velocity = newVel * speed * Time.fixedDeltaTime; // set new velocity to be the one from input * speed value scaled by deltatime
        Vector3 newDir = new Vector3(Input.GetAxis("Rhorizontal"), 0.0f, Input.GetAxis("Rvertical"));
        playerRigidbody.rotation = Quaternion.LookRotation(newDir * Time.fixedDeltaTime);      // set players orientation == direction of second analog stick/axis
    }

}
