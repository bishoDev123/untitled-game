using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;

    private Rigidbody2D rb;
    private Vector2 direction;

    public HealthbarController HPdisplay;

    public float speed;
    public float health;
    public float maxHealth;

    //tells whether this enemy is flying back from knockback
    private bool knocking;

    // Start is called before the first frame update
    void Start()
    {
        knocking = false;

        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the direction the player is from the enemy
        direction = player.position - transform.position;

        //only set the exact velocity when not experiencing a knockback
        if (!knocking)
        {
            //moves the enemy based on the direction
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        
        


        HPdisplay.SetHealth(health, maxHealth);


    }


    private void FixedUpdate()
    {
        //this is needed for the knockback so that the knockback slows down
        if (rb.velocity.magnitude > 0.0f && knocking)
        {
            rb.velocity *= 0.9f;
            if (rb.velocity.magnitude < .5f)
            {
                knocking = false;
                rb.velocity = Vector2.zero;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "weapon")
        {
            knockBackSelf();
            
            health -= 1;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void knockBackSelf()
    {
        knocking = true;
        //gets the direction vector from the player to this enemy
        Vector3 dir = (transform.position - PlayerMovement.PM.transform.position).normalized;
        //adds a velocity vector in that direction multiplied by the weapon power
        rb.velocity += new Vector2(dir.x, dir.y)  * GameManager.GM.diceUp * 5.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject == PlayerMovement.PM.gameObject)
        {
            PlayerMovement.PM.addKnockback(transform.position);
        }
    }
}
