using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_enemy_AI : MonoBehaviour {
    public float move_speed;
    public float rotate_speed;
    public float x1;
    public float x2;
    public float z1;
    public float z2;
    public float waitTime;
    private float localTime;
    private Vector3 hotspot;
    public int health;
    private Vector3 targetDir;
    private float distance;
    private float move_step;
    private float rotate_step;
    private EnemyShoot es;
    // Use this for initialization
    void Start()
    {
        localTime = waitTime;
        es = GetComponent<EnemyShoot>();
        hotspot = new Vector3(Random.Range(x1, x2), transform.position.y, Random.Range(z1, z2));
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        distance = Vector3.Distance(hotspot, transform.position);
        targetDir = hotspot - transform.position;
        if (distance > 0.1f)
        {
            es.SetPattern(0);
            localTime = waitTime;
            move_step = move_speed * Time.deltaTime;
            rotate_step = rotate_speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hotspot, move_step);
            transform.forward = Vector3.RotateTowards(transform.forward, targetDir, rotate_step, 0.0f);
        }
        else
        {
            es.SetPattern(1);
            localTime -= Time.deltaTime;
            if(localTime > 0)
            {
                transform.Rotate(0, rotate_speed * Time.deltaTime,0);
            }
            else
            {
                hotspot = new Vector3(Random.Range(x1, x2), transform.position.y, Random.Range(z1, z2));
            }
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
