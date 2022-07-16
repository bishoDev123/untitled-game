using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{

    public float cardHolderParkDist;

    private Rigidbody2D rb;

    public GameObject cardMissile;
    
    
    private float prevJumpTime;
    private float prevLaunchTime;


    // Start is called before the first frame update
    void Start()
    {
        

        rb = gameObject.GetComponent<Rigidbody2D>();
        prevJumpTime = 0.0f;
        prevLaunchTime = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        
        float dist = cardHolderParkDist - Vector2.Distance(transform.position, PlayerMovement.PM.transform.position);
        if (Mathf.Abs(dist) > 1.0f && Time.time - prevJumpTime > 3.0f)
        {
            Vector3 dir = (transform.position - PlayerMovement.PM.transform.position).normalized;
            rb.velocity += 10.0f * new Vector2(dir.x, dir.y) * Mathf.Sign(dist);

            prevJumpTime = Time.time;
        }

        if(Time.time - prevLaunchTime > 10.0f)
        {

            prevLaunchTime = Time.time;
            Dealer.CardMaster.requestLaunch(3, transform);
        }

        
    }


    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0.0f)
        {
            rb.velocity *= 0.9f;

            if (rb.velocity.magnitude < 0.5f)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
