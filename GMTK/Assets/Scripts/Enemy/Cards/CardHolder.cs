using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour
{

    public float cardHolderParkDist;

    private Rigidbody2D rb;
    
    
    
    private float prevTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        prevTime = 0.0f;
    }


    // Update is called once per frame
    void Update()
    {
        
        float dist = cardHolderParkDist - Vector2.Distance(transform.position, PlayerMovement.PM.transform.position);
        if (Mathf.Abs(dist) > 1.0f && Time.time - prevTime > 3.0f)
        {
            Vector3 dir = (transform.position - PlayerMovement.PM.transform.position).normalized;
            rb.velocity += 10.0f * new Vector2(dir.x, dir.y) * Mathf.Sign(dist);

            prevTime = Time.time;
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
