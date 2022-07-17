using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement PM;

    public GameObject playerGameObject;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveDirection;
    
    public float speed;
    public float cooldownTime;

    private float moveX;
    private float moveY;
    private float nextMoveTime = 0;

    public float stopSpeed;

    public float knockback;

    void Start()
    {
        //makes sure there is only one player movement script
        if (PM == null)
        {
            PM = this;
        }
        else if (PM != this)
        {
            Destroy(gameObject);
        }

        playerGameObject = gameObject;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.color = Color.green;
        if (Time.time > nextMoveTime)
        {
            //if the certain movement key is pressed
            if (Input.GetKeyDown(InputManager.IM.forward))
            {
                //add the up vector velocity times the number on the back of the dice, times the default speed
                rb.velocity += Vector2.up * (float)GameManager.GM.diceBack * speed;

                //get a new dice number setup
                GameManager.GM.rollDie();

                //reset the cooldown time
                nextMoveTime = Time.time + cooldownTime;

            }
            if (Input.GetKeyDown(InputManager.IM.left))
            {
                rb.velocity -= Vector2.right * (float)GameManager.GM.diceBack * speed;
                GameManager.GM.rollDie();
                nextMoveTime = Time.time + cooldownTime;
            }
            if (Input.GetKeyDown(InputManager.IM.right))
            {
                rb.velocity += Vector2.right * (float)GameManager.GM.diceBack * speed;
                GameManager.GM.rollDie();
                nextMoveTime = Time.time + cooldownTime;
            }
            if (Input.GetKeyDown(InputManager.IM.backward))
            {
                rb.velocity -= Vector2.up * (float)GameManager.GM.diceBack * speed;
                GameManager.GM.rollDie();
                nextMoveTime = Time.time + cooldownTime;
            }
        }
        else 
        {
            sr.color = Color.red;
        }

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        KeyCode[] ops = InputManager.IM.diceOptions[GameManager.GM.diceUp];
        for(int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(ops[i]))
            {

            }
        }
        */

        
        if(rb.velocity.magnitude > 0.0f)
        {
            if(rb.velocity.magnitude < stopSpeed)
            {
                rb.velocity = Vector2.zero;
            }
            rb.velocity *= 0.9f;
        }

    }
    public void addKnockback(Vector3 position)
    {
        Vector3 dir = (transform.position - position).normalized;
        rb.velocity += (new Vector2(dir.x, dir.y) * knockback);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("exit"))
        {
            SceneManager.LoadScene(2);
        }
    }


}
