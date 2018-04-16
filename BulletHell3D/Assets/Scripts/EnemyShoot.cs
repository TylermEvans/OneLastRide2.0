using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private PatternConfig[] patterns;

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
    
    /*
     *  To set enemy firing pattern, create a new pattern from the prefab
     *      and set its properties in the inspector. Then attach it to the PatternConfig array
     *      also in the inspector. Lastly, call the SetPattern function and pass in the index of
     *      the pattern you want to use.
     */

    private Bullet bullet;
    private float weaponCoolDown;
    private int numPaths;
    private int numBullets;
    private float bulletDelay;
    private float pathDistGap;
    private float pathAngleGap;
    private bool shootsRadial;
    private int currentPattern = 0;

    private void Start()
    {
        if(patterns.Length > 0)
        {
            SetPattern(currentPattern);
        }
        else
        {
            Debug.Log(this.name + " has no fire pattern.");
        }
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

    private void SetPattern(int index)
    {
        if(index < patterns.Length)
        {
            // Assigning/clamping default values
            weaponCoolDown = Mathf.Clamp(patterns[index].weaponCoolDown, 1, 10);
            numPaths = Mathf.Clamp(patterns[index].numPaths, 1, 10);
            numBullets = Mathf.Clamp(patterns[index].numBullets, 1, 10);
            bulletDelay = Mathf.Clamp(patterns[index].bulletDelay, 0.1f, weaponCoolDown / numBullets);
            pathDistGap = Mathf.Clamp(patterns[index].pathDistGap, 0.25f, 10);
            pathAngleGap = Mathf.Clamp(patterns[index].pathAngleGap, 15, 360 / numPaths);
            bullet = patterns[index].bullet;

            numPathsIsEven = numPaths % 2 == 0;

            weaponTimer = weaponCoolDown;
            numLeftToFire = numBullets;
        }
        else
        {
            Debug.Log("Error: Attempting to set pattern to " + index + " for " + this.name + ".");
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
