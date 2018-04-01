using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public int bulletLife;
	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        if (bulletLife <= 0)
        {
            Destroy(gameObject);
        }
        bulletLife--;
       
    }
}
