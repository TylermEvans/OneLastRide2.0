using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // How many trails of bullets per each firing
    [SerializeField]
    private int numBulletPaths;

    // How many times the weapon will fire
    [SerializeField]
    private int numBulletsPerPath; // DOES NOTHING YET

    [SerializeField]
    private float weaponCoolDown;

    // Amount of time between successive bullets
    [SerializeField]
    private float bulletGapTime; // DOES NOTHING YET

    // Distance between bullet paths
    [SerializeField]
    private float bulletPathGap;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float health; // DOES NOTHING YET

    [SerializeField]
    private bool weaponFiresRadially; // DOES NOTHING YET
    
    [SerializeField]
    private float bulletSpeed; // DOES NOTHING YET

    private float bulletStartX;
    private float bulletStartY;
    private float bulletStartZ;

    // Used to center paths on the enemy
    private bool numPathsIsEven;

    private float weaponTimer;
    private float bulletGapTimer;
    private float numLeftToFire;

    private void Start()
    {
        bulletStartY = transform.position.y;
        bulletStartZ = transform.position.z + transform.forward.z;
        numPathsIsEven = numBulletPaths % 2 == 0;

        weaponTimer = weaponCoolDown;
        numLeftToFire = numBulletsPerPath;
    }

    private void FixedUpdate ()
    {
        weaponTimer -= Time.fixedDeltaTime;
        if(weaponTimer <= 0)
        {
            FireLinear();
            weaponTimer = weaponCoolDown;
        }
	}

    private void FireLinear()
    {
        if(numPathsIsEven)
        {
            bulletStartX = transform.position.x - ((numBulletPaths / 2 - 0.5f) * bulletPathGap);
            for(int i = 0; i < numBulletPaths; i++)
            {
                float bx = bulletStartX + i * bulletPathGap;
                Vector3 bpos = new Vector3(bx, bulletStartY, bulletStartZ);
                Instantiate(bullet, bpos, Quaternion.LookRotation(transform.forward));
            }
        }
        else
        {

        }
    }

    private void FireRadial()
    {

    }
}
