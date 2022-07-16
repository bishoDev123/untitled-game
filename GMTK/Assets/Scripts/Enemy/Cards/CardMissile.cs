using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMissile : MonoBehaviour
{
    public float missileSpeed;


    private float startAng;
    private Rigidbody2D rb;

    private bool starting;

    // Start is called before the first frame update
    void Start()
    {

        //start at the parents location
        transform.position = gameObject.GetComponentInParent<Transform>().position;

        //the starting animation
        starting = true;

        //set rigidbody
        rb = gameObject.GetComponent<Rigidbody2D>();


        //what angle does it "launch" away from parent at start
        startAng = Random.Range(0.0f, 6.28f);

        //shuffle away from parent
        rb.velocity = new Vector2(Mathf.Cos(startAng), Mathf.Sin(startAng)) * 10.0f;

        //add a little pin to the shuffle for style
        rb.AddTorque(Random.Range(-100.0f, 100.0f));


    }

    // Update is called once per frame
    void Update()
    {

        if (!starting)
        {
            Vector3 dir = (PlayerMovement.PM.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(dir.x, dir.y) * missileSpeed;

            //angle that the spear should point towards (the player)
            float pointAng = Mathf.Atan2(dir.y, dir.x);
            //point the spear at the player
            transform.rotation = Quaternion.Euler(0f, 0f, (pointAng * Mathf.Rad2Deg) - 90);
        }


    }

    private void FixedUpdate()
    {

        if (starting)
        {
            if (rb.velocity.magnitude > 0.0f)
            {
                rb.velocity *= 0.9f;

                if (rb.velocity.magnitude < 0.5f)
                {
                    rb.velocity = Vector2.zero;
                    starting = false;
                }
            }
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == PlayerMovement.PM.gameObject)
        {
            Destroy(gameObject);
        }



    }
}
