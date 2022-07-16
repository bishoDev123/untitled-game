using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D hb;
    private Vector2 moveDirection;
    private Vector2 swrdMov;
    public float speed;
    private float moveX;
    private float moveY;
    private float thrust = 50f;
    private float setback = -50f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hb = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputManager.IM.forward))
        {
            rb.velocity += Vector2.up * (float)GameManager.GM.diceBack;
        }
        if (Input.GetKeyDown(InputManager.IM.left))
        {
            rb.velocity -= Vector2.right * (float)GameManager.GM.diceBack;
        }
        if (Input.GetKeyDown(InputManager.IM.right))
        {
            rb.velocity += Vector2.right * (float)GameManager.GM.diceBack;
        }
        if (Input.GetKeyDown(InputManager.IM.backward))
        {
            rb.velocity -= Vector2.up * (float)GameManager.GM.diceBack;
        }
        if (Input.GetKeyDown(InputManager.IM.jump))
        {
            rb.AddForce(transform.right * thrust);
            hb.enabled = true;
        }
        if(Input.GetKeyUp(InputManager.IM.jump))
        {
            rb.AddForce(transform.right * setback);
            hb.enabled = false;
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


        if (rb.velocity.magnitude > 0.0f)
        {
            rb.velocity *= 0.9f;
        }

    }
}
