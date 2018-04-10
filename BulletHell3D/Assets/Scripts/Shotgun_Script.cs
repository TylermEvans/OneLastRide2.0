using System;
using UnityEngine;

public class Shotgun_Script : WeaponBaseClass {

    void Start()
    {
        this.GetComponent<Renderer>().material.color = new Color(1, 0.2f, 1);
        oldTime = bulletCooldown;
        mOwner = null;
    }

    void Update() {

        if (mOwner != null)
        {
            shoot();
        }
    }

    public void shoot()
    {

        float attack = Input.GetAxis("PrimaryAttack");
        Vector3 newpos = this.mOwner.transform.position + this.mOwner.transform.forward * 1;
        bulletCooldown -= Time.deltaTime; // bullet countdown
        if ((attack != 0 || Input.GetKeyDown("space")) && bulletCooldown <= 0) // attack with space bar or right trigger on gamepad
        {
            if (this.mOwner.transform.forward != Vector3.zero)
            {
                Instantiate(bullet, newpos, Quaternion.LookRotation(this.mOwner.transform.forward)); // create bullet
                //b.mOwner = this.mOwner;
                bulletCooldown = oldTime; // reset bullet cooldown
            }

        }
        // refer to pattern and do something ?
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().weapon != null)
            {
                Destroy(other.gameObject.GetComponent<PlayerController>().weapon);
            }
            setOwner(other.gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
