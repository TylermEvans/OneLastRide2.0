﻿using System;
using UnityEngine;

public class Shotgun_Script : MonoBehaviour, WeaponInterface {

    // member variables
    int damage = 4;
    int speed = 3;
    //Pattern shot_pattern
    //double timer;
    string weapon_name = "shotgun";
    // public png whatever idk fuck this class

    // Use this for initialization
    void Start () {
		// ...
	}
	
	// Update is called once per frame
	void Update () {
		// uhhh
	}

    public void shoot() {
        // refer to pattern and do something ?
    }

    public void print_stats() {
        Console.WriteLine("damage: {0}\n speed: {1}", damage, speed);
        // wow this is easily the ugliest print function i've ever seen
    }

    void onPickUp() {
        //
    }

}
