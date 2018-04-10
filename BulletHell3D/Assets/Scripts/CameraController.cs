using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public float camHeight = 50.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }
    void Update ()
    {
        if (player != null)
        {
            Vector3 pos = rb.position;
            pos.y += camHeight;
            pos.z -= 10;
            transform.position = pos;
        }
        
	      
	}
}
