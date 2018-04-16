using UnityEngine;

public class PatternConfig : MonoBehaviour
{
    // The type of bullet to fire
    [SerializeField]
    public Bullet bullet;

    [SerializeField]
    public float weaponCoolDown;

    // How many trails of bullets per each firing
    [SerializeField]
    public int numPaths;

    // How many times the weapon will fire
    [SerializeField]
    public int numBullets;

    // Amount of time between successive bullets
    [SerializeField]
    public float bulletDelay;

    // Distance between bullet paths (for linear)
    [SerializeField]
    public float pathDistGap;

    // Angle(degrees) between bullet paths (for radial)
    [SerializeField]
    public float pathAngleGap;

    [SerializeField]
    public bool shootsRadial;
}
