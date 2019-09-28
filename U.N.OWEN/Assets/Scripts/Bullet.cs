using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int direction;
    private int disappearTime = 0;
    private int horizontal;
    private int vertical;

    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (direction == 1)
        {
            horizontal = 0;
            vertical = 1;
        }
        else if (direction == 2)
        {
            horizontal = 1;
            vertical = 0;
        }
        else if (direction == 3)
        {
            horizontal = 0;
            vertical = -1;
        }
        else
        {
            horizontal = -1;
            vertical = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        disappearTime += 1;
        transform.position = new Vector2(transform.position.x + horizontal * speed * Time.deltaTime, transform.position.y + vertical * speed * Time.deltaTime);
    }
}
