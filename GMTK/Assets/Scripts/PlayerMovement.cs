using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    public float speed;

    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(InputManager.IM.forward))
        {
            rb.velocity += Vector2.up * (float)GameManager.GM.diceBack;
            GameManager.GM.rollDie();
        }
        if (Input.GetKeyDown(InputManager.IM.left))
        {
            rb.velocity -= Vector2.right * (float)GameManager.GM.diceBack;
            GameManager.GM.rollDie();
        }
        if (Input.GetKeyDown(InputManager.IM.right))
        {
            rb.velocity += Vector2.right * (float)GameManager.GM.diceBack;
            GameManager.GM.rollDie();
        }
        if (Input.GetKeyDown(InputManager.IM.backward))
        {
            rb.velocity -= Vector2.up * (float)GameManager.GM.diceBack;
            GameManager.GM.rollDie();
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

    }
}
