using System;
using UnityEngine;

public class Pistol_Script : MonoBehaviour, WeaponInterface {

    // member variables
    int damage = 1;
    int speed = 2;
    //Pattern shot_pattern
    //double timer;
    string wname = "pistol";

    // Use this for initialization
    void Start()
    {
        // ...
    }

    // Update is called once per frame
    void Update()
    {
        // uhhh
    }

    public void shoot()
    {
        // refer to pattern and do something ?
    }

    public void print_stats()
    {
        Console.WriteLine("damage: {0}\n speed: {1}", damage, speed);
        // wow this is easily the ugliest print function i've ever seen
    }
}
