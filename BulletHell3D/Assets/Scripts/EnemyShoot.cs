using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // The type of bullet to fire
    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private float weaponCoolDown;

    // How many trails of bullets per each firing
    [SerializeField]
    private int numPaths;

    // How many times the weapon will fire
    [SerializeField]
    private int numBullets;
    
    // Amount of time between successive bullets
    [SerializeField]
    private float bulletDelay;

    // Distance between bullet paths (for linear)
    [SerializeField]
    private float pathDistGap;

    // Angle(degrees) between bullet paths (for radial)
    [SerializeField]
    private float pathAngleGap;
    
    [SerializeField]
    private bool shootsRadial;

    // Transform coordinates
    private float tx;
    private float ty;
    private float tz;

    private float xOffset;
    private float angleOffset;

    // Used to center paths on the enemy
    private bool numPathsIsEven;

    private float weaponTimer;
    private float bulletTimer;
    private float numLeftToFire;

    private void Start()
    {
        // Assigning/clamping default values
        weaponCoolDown = Mathf.Clamp(weaponCoolDown, 1, 10);
        numPaths = Mathf.Clamp(numPaths, 1, 10);
        numBullets = Mathf.Clamp(numBullets, 1, 10);
        bulletDelay = Mathf.Clamp(bulletDelay, 0.1f, weaponCoolDown / numBullets);
        pathDistGap = Mathf.Clamp(pathDistGap, 0.25f, 10);
        pathAngleGap = Mathf.Clamp(pathAngleGap, 15, 360 / numPaths);

        numPathsIsEven = numPaths % 2 == 0;

        weaponTimer = weaponCoolDown;
        numLeftToFire = numBullets;
    }

    private void FixedUpdate ()
    {
        tx = transform.position.x;
        ty = transform.position.y;
        tz = transform.position.z + transform.forward.z;

        weaponTimer -= Time.fixedDeltaTime;
        bulletTimer -= Time.fixedDeltaTime;

        if(weaponTimer <= 0)
        {
            numLeftToFire = numBullets;
            weaponTimer = weaponCoolDown;
        }
        if(numLeftToFire > 0 && bulletTimer <= 0)
        {
            if(shootsRadial)
            {
                FireRadial();
            }
            else
            {
                FireLinear();
            }
            numLeftToFire--;
            bulletTimer = bulletDelay;
        }
    }

    private void FireLinear()
    {
        if (numPathsIsEven)
        {
            xOffset = tx - ((numPaths / 2 - 0.5f) * pathDistGap);
        }
        else
        {
            xOffset = tx - (numPaths - 1) / 2 * pathDistGap;
        }
        for (int i = 0; i < numPaths; i++)
        {
            float bx = xOffset + i * pathDistGap;
            Vector3 bpos = new Vector3(bx, ty, tz);
            Instantiate(bullet, bpos, Quaternion.LookRotation(transform.forward));
            //b.mOwner = this.gameObject;
        }
    }

    private void FireRadial()
    {
        if(numPathsIsEven)
        {
            angleOffset = transform.rotation.z + ((numPaths / 2) - 0.5f) * pathAngleGap;
        }
        else
        {

        }
        for(int i = 0; i < numPaths; i++)
        {
            float bx = Mathf.Cos(angleOffset + i * pathAngleGap)+transform.position.x;
            float bz = Mathf.Sin(angleOffset + i * pathAngleGap)+transform.position.z;
            Vector3 bpos = new Vector3(bx, ty, bz);
            Vector3 bdir = (bpos - transform.position).normalized;
           Instantiate(bullet, bpos, Quaternion.LookRotation(bdir));
            

        }
    }
    public void PanicFire()
    {
        shootsRadial = true;
        numPaths = 6;
    }
    public void EndPanicFire()
    {
        shootsRadial = false;
        numPaths = 1;
    }
}
