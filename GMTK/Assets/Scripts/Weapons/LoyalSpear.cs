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

                //get the mouse position in world coordinates and the direction from the spear to the mouse
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 dir = (mp - transform.position).normalized;

                
                //make the spear revolve around the player
                transform.position = PlayerMovement.PM.playerGameObject.transform.position + new Vector3(Mathf.Cos(rotAngle), Mathf.Sin(rotAngle), 0.0f);

                //angle that the spear should point towards (the mouse)
                float pointAng = Mathf.Atan2(dir.y, dir.x);
                //point the spear at the mouse
                transform.rotation = Quaternion.Euler(0f, 0f, (pointAng * Mathf.Rad2Deg) - 90);

                //change the revolve angle by 2 radians per second
                rotAngle += 2.0f * Time.deltaTime;

                //if the spear hasnt been thrown then throw it
                if (Input.GetKeyDown(InputManager.IM.MBOne))
                {
                    //just got thrown
                    thrown = true;


                    //get the hit place for the spear target
                    RaycastHit2D rayHit = Physics2D.Raycast(mp, Vector2.zero);
                    elec.Play();



                    if (rayHit)
                    {
                        //if the ray hit, then set the target to where the mouse clicked
                        target = rayHit.point;
                        //set the spear on a course for the target
                        spearR.velocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * spearVelocity;
                        //add a little error in the spears point direction to make it look realer
                        transform.Rotate(new Vector3(0f, 0f, 1f), Random.Range(-10f, 10f));
                    }
                }
            }

            
        }
        else
        {

            if (tumbling)
            {
                //if it has hit the target and is tumbling, then slow it down a little bit
                spearR.velocity *= 0.99f;
                spearR.angularVelocity *= 0.99f;
            }


            if(Input.GetKeyDown(InputManager.IM.MBTwo))
            {
                //if tumbling and called back then return to the player
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
