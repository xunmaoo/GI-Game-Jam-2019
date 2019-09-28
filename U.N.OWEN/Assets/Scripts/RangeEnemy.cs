using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShot;

    public GameObject projectile;

    public bool getAttacked = false;

    public int hp = 1;

    public 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        Shoot();

        if (getAttacked == true) GetAttacked();

        Die();
    }

    void GetAttacked()
    {
        int bounce_time = 0;

        while (bounce_time < 60)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            bounce_time += 1;
        }

        getAttacked = false;
    }

    void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Die()
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
