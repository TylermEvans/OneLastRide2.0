using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    public int bulletLife;
    public float bspeed;
    public GameObject mOwner;
    //public Pattern bullet_pattern ?

    void Start() { }

    private void Update()
    {
        transform.position += transform.forward * bspeed * Time.deltaTime;
        if (bulletLife <= 0)
        {
            Destroy(gameObject);
        }
        bulletLife--;

    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag != mOwner.tag)
        {
            if(other.gameObject.GetComponent<PlayerController>())
            {
                other.gameObject.GetComponent<PlayerController>().health -= 10;
            }
            else if(other.gameObject.GetComponent<Basic_enemy_AI>())
            {
                other.gameObject.GetComponent<Basic_enemy_AI>().health -= 10;
            }
        }*/
        Destroy(gameObject);

    }

}
