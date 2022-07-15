using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    private Rigidbody2D rb;
    private Vector2 direction;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the direction the player is from the enemy
        direction = player.position - transform.position;
        
        //moves the enemy based on the direction
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
