using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int bulletLife;
    public float bspeed;
    //public Pattern bullet_pattern ?

	void Start () {}

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
        if (other.gameObject.name == "Player")
        {

        }
        else
        {
            Destroy(gameObject);
        }
        
    }

}
