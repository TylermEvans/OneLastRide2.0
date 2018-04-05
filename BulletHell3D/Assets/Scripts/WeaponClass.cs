using System;
using UnityEngine;

abstract public class WeaponBaseClass : MonoBehaviour {

    public int damage;
    public int speed;
    //public Pattern shot_pattern
    public string weapon_name;

    //abstract public void shoot();
    public void print_stats() {
        Console.WriteLine("damage: {0}\n speed: {1}", damage, speed);
        Console.WriteLine(weapon_name);
    } // idk i figure this could be useful

}