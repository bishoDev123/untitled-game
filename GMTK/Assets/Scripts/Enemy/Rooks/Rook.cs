using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    public float dashDelay;
    public float dashSpeed;
    public float dashDistance;

    private float prevDashTime;

    private bool strtDash;
    private Rigidbody2D rb;

    private GameObject target;


    private Vector3 dashStart;
    private Vector3 dashEnd;
    private Vector3 dir;

    private bool interfered;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 7);

        strtDash = false;

        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    //  private Vector3 Roamer()
    //  {
    //       return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    //  }

    //  private Vector3 GetRoamingDirection()
    //   {
    //      return startingPosition + Roamer() * Random.Range(10f, 70f);
    //  }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - prevDashTime >= dashDelay)
        {
            target = Instantiate(Dealer.CardMaster.rookTarget, transform);
            target.SetActive(true);

            //prevDashTime = Time.time;
            dashStart = transform.position;
            dashEnd = PlayerMovement.PM.transform.position;

            dir = (dashEnd - dashStart).normalized;

            prevDashTime = Time.time;
        }

        if (strtDash)
        {

            rb.velocity = new Vector2(dir.x, dir.y) * dashSpeed;

            strtDash = false;
        }
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(dashStart, transform.position) > dashDistance + 0.5f)
        {
            rb.velocity = Vector2.zero;
        }


        if (interfered && rb.velocity.magnitude > 0.0f)
        {
            rb.velocity *= 0.9f;
            if (rb.velocity.magnitude < 0.5f)
            {
                rb.velocity = Vector2.zero;
            }
        }

    }

    void startDash()
    {
        strtDash = true;
        interfered = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        interfered = true;

        if (collision.gameObject == PlayerMovement.PM.gameObject)
        {
            HealthHandler.HH.dockHealth(1f);
            PlayerMovement.PM.addKnockback(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            //rb.velocity = Vector2.zero;
        }
    }
}