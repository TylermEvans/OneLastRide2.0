using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_enemy_AI : MonoBehaviour {
    public Transform target;
    public float move_speed;
    public float rotate_speed;
    public float d1;
    public float d2;
    public int health;
    private Vector3 targetDir;
    private float distance;
    private float move_step;
    private float rotate_step;
    private EnemyShoot es;

    scoreCounter score;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
        score = GameObject.Find("ScoreCounterObj").GetComponent<scoreCounter>();
        es = GetComponent<EnemyShoot>();
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            ///increment score here
            score.add(10);
            Destroy(gameObject);
        }
        if (target)
        {
            targetDir = target.position - transform.position;
            distance = Vector3.Distance(target.position, transform.position);
            move_step = move_speed * Time.deltaTime;
            rotate_step = rotate_speed * Time.deltaTime;
            if (distance > d1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, move_step);
            }
            if (distance < d2)
            {
                es.PanicFire();
            }
            if (distance > d2)
            {
                es.EndPanicFire();
            }
            transform.forward = Vector3.RotateTowards(transform.forward, targetDir, rotate_step, 0.0f);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet" && other.gameObject.GetComponent<Bullet>().mOwner.tag == "Player")
        {
            health -= 10;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
