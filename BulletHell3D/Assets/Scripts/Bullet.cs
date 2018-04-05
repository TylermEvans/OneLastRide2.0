using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int bulletLife;
    //public Pattern bullet_pattern ?

	void Start () {}

    public void update(PlayerController p) {
        transform.position += transform.forward * p.weapon.speed * Time.fixedDeltaTime;
        if (bulletLife <= 0)
        {
            Destroy(gameObject);
        }
        bulletLife--;
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
