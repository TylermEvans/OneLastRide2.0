using System;
using UnityEngine;

public class Shotgun_Script : WeaponBaseClass {

    void Start()
    {
        weapon_name = "shotgun";
        speed = 3;
        damage = 4;
    }

    void Update() { }

    public void shoot()
    {
        // refer to pattern and do something ?
    }

    public void print_stats()
    {
        Console.WriteLine("damage: {0}\n speed: {1}", damage, speed);
        Console.WriteLine(weapon_name);
    }
}
