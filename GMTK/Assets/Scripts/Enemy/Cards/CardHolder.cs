using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{

    public float cardHolderParkDist;
    public float jumpDelay;
    public float launchDelay;
    public int launchAmount;
    

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
        //get the distance from the cardPark distance radius (so if its 5 away from player and park dist is 8, dist will be 3)
        float dist = cardHolderParkDist - Vector2.Distance(transform.position, PlayerMovement.PM.transform.position);
        //if further than 3 away from park distance
        if (Mathf.Abs(dist) > 1.0f && Time.time - prevJumpTime > jumpDelay)
        {
            //get the direction from player to this enemy
            Vector3 dir = (transform.position - PlayerMovement.PM.transform.position).normalized;
            //move either closer or further from player
            rb.velocity += 10.0f * new Vector2(dir.x, dir.y) * Mathf.Sign(dist);
            //reset jump timer
            prevJumpTime = Time.time;
        }

        //launch cards 
        if(Time.time - prevLaunchTime > launchDelay)
        {

            prevLaunchTime = Time.time;
            Dealer.CardMaster.requestLaunch(launchAmount, transform);
        }

        
    }

    private void FixedUpdate()
    {
        //friction
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
