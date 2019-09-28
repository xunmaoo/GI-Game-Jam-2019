using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private GameObject player;
    public float step = 0.1f;
    public float maxDist = 10f;

    private int direction = -1;
    private int moves = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist < maxDist) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step/5 * Time.deltaTime);
        else
        {
            moves += 1;
            transform.position = new Vector3(transform.position.x + direction * step * Time.deltaTime, transform.position.y, transform.position.z);

            if (moves >= 60)
            {
                moves = 0;
                direction = -direction;
            }
        }
    }
}
