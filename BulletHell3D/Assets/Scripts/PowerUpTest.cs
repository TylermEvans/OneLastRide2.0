﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PowerUpTest /* : MonoBehaviour */ {

    /*
    // member variables
    //double timer;
    //string name; // ie "shotgun"
    //Pattern shot_pattern
    public int damage;
    public float speed;
    public png whatever idk fuck this class
    */

    // Use this for initialization
    void Start();

    // Update is called once per frame
    void Update();

    void onPickUp();
}
