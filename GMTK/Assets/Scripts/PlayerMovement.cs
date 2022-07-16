using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveDirection;
    
    public float speed;
    public float cooldownTime;

    private float moveX;
    private float moveY;
    private float nextMoveTime = 0;
    private Vector2 moveDirection;
    
    public float speed;

    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.color = Color.green;
        if (Time.time > nextMoveTime)
        {
            
            if (Input.GetKeyDown(InputManager.IM.forward))
            {
                rb.velocity += Vector2.up * (float)GameManager.GM.diceBack;
                GameManager.GM.rollDie();
                nextMoveTime = Time.time + cooldownTime;
            }
            if (Input.GetKeyDown(InputManager.IM.left))
            {
                rb.velocity -= Vector2.right * (float)GameManager.GM.diceBack;
                GameManager.GM.rollDie();
                nextMoveTime = Time.time + cooldownTime;
            }
            if (Input.GetKeyDown(InputManager.IM.right))
            {
                rb.velocity += Vector2.right * (float)GameManager.GM.diceBack;
                GameManager.GM.rollDie();
                nextMoveTime = Time.time + cooldownTime;
            }
            if (Input.GetKeyDown(InputManager.IM.backward))
            {
                rb.velocity -= Vector2.up * (float)GameManager.GM.diceBack;
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
            rb.velocity *= 0.9f;
        }
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);

        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);

    }
}
