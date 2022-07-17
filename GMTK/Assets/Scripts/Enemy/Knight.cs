using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float jumpDelay;
    public float jumpDuration;
    public float jumpDistance;
    public float jumpPause;
    public float jumpSpeed;

    private float prevJumpTime;
    private Rigidbody2D rb;
    private bool midJump;
    private bool endJump;

    private float jumpingAng;
    private float coinFlip;


    private Animation anim;
    public AnimationClip knightclip;
    // Start is called before the first frame update
    void Start()
    {
        //45 45 90 triangle where knight travels along the two small sides
        //jumpSpeed = (jumpDistance * Mathf.Sqrt(2.0f)) / jumpDuration; 

        anim = GetComponent<Animation>();
        anim.clip = knightclip;

        rb = gameObject.GetComponent<Rigidbody2D>();

        prevJumpTime = 0.0f;



        //you cant start another jump in the middle of one
        if(jumpDelay < jumpDuration)
        {
            jumpDelay = jumpDuration + 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - prevJumpTime > jumpDelay)
        {
            
            anim.Play();

            coinFlip = Mathf.Sign(Random.Range(-1.0f, 1.0f));

            

            Vector3 dir = (PlayerMovement.PM.transform.position - transform.position).normalized;
            
            

            //angle that the spear should point towards (the player)
            jumpingAng = Mathf.Atan2(dir.y, dir.x);
            //point the spear at the player

            jumpingAng += (1.57f * coinFlip);

            rb.velocity = new Vector2(Mathf.Cos(jumpingAng), Mathf.Sin(jumpingAng)) * (jumpSpeed * .3f);

            midJump = true;
            prevJumpTime = Time.time;

            //transform.rotation = Quaternion.Euler(0f, 0f, (pointAng * Mathf.Rad2Deg) - 90 + (45.0f * coinFlip));
        }

        if (midJump)
        {
            if (Time.time - prevJumpTime >= jumpPause)
            {
                Vector3 dir = (PlayerMovement.PM.transform.position - transform.position).normalized;

                //angle that the spear should point towards (the player)
                jumpingAng = Mathf.Atan2(dir.y, dir.x);
                
                rb.velocity = new Vector2(Mathf.Cos(jumpingAng), Mathf.Sin(jumpingAng)) * jumpSpeed;

                midJump = false;
                endJump = true;
            }
        }

        if (endJump && Time.time - prevJumpTime >= jumpDuration)
        {
            anim.Stop();
            rb.velocity = Vector2.zero;
        }
    }


    private void FixedUpdate()
    {
        if(rb.velocity.magnitude > 0.0f)
        {
            rb.velocity *= 0.9f;
            if(rb.velocity.magnitude < 0.5f)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == PlayerMovement.PM.gameObject)
        {
            HealthHandler.HH.dockHealth(1f);
            PlayerMovement.PM.addKnockback(transform.position);
        }
    }
}
