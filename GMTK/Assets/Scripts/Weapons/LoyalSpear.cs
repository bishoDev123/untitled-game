using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoyalSpear : MonoBehaviour
{
    public static LoyalSpear LS;
    public ParticleSystem elec;

    float rotAngle;

    public Vector2 target { get; set; }
    
    
    public Rigidbody2D spearR;

    public GameObject spearTarget;

    public float spearVelocity;

    public GameObject player;
    public GameObject spear;





    public bool thrown { get; set; }

    public bool tumbling { get; set; }

    public bool returning { get; set; }

    // Start is called before the first frame updates
    void Start()
    {
        //makes sure there is only one loyal spear script
        if (LS == null)
        {
            LS = this;
        }
        else if (LS != this)
        {
            Destroy(gameObject);
        }

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), spear.GetComponent<Collider2D>());


        thrown = false;
        tumbling = false;
        rotAngle = 0.0f;
        elec.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thrown)
        {

            if (returning)
            {
                if(Vector2.Distance(player.transform.position, transform.position) < 1.0f)
                {
                    returning = false;
                    Vector2 dir = (transform.position - player.transform.position).normalized;
                    rotAngle = Mathf.Atan2(dir.y, dir.x);
                    elec.Stop();
                }

                spearR.velocity = (player.transform.position - transform.position).normalized * spearVelocity * 0.7f;

            }
            else
            {
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = (mp - transform.position).normalized;

                

                transform.position = PlayerMovement.PM.playerGameObject.transform.position + new Vector3(Mathf.Cos(rotAngle), Mathf.Sin(rotAngle), 0.0f);


                float pointAng = Mathf.Atan2(dir.y, dir.x);

                transform.rotation = Quaternion.Euler(0f, 0f, (pointAng * Mathf.Rad2Deg) - 90);


                rotAngle += 2.0f * Time.deltaTime;

                //if the spear hasnt been thrown then throw it
                if (Input.GetKeyDown(InputManager.IM.MBOne))
                {
                    thrown = true;


                    //r.direction = new Vector3(0.0f, 0.0f, 1.0f);
                    //r.origin = Input.mousePosition;
                    RaycastHit2D rayHit = Physics2D.Raycast(mp, Vector2.zero);
                    elec.Play();



                    if (rayHit)
                    {
                        target = rayHit.point;
                        spearR.velocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * spearVelocity;
                        transform.Rotate(new Vector3(0f, 0f, 1f), Random.Range(-10f, 10f));
                    }
                }
            }

            
        }
        else
        {

            if (tumbling)
            {
                spearR.velocity *= 0.99f;
                spearR.angularVelocity *= 0.99f;
            }


            if(Input.GetKeyDown(InputManager.IM.MBTwo))
            {
                returning = true;

                spearR.angularVelocity = 0.0f;
                spearR.velocity = Vector2.zero;
                thrown = false;
                tumbling = false;
                
            }
            
        }
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == spearTarget)
        {
            tumbling = true;
            spearR.AddTorque(Random.Range(-100f, 100f));
            spearR.velocity *= 0.1f;
        }
    }
}
