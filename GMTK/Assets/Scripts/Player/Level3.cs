using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{
    public Collider2D targetCollider;
    public GameObject cards1;
    public GameObject cards2;
    public GameObject cards3;

    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;

    private bool touching;

    private bool portalActive;

    // Start is called before the first frame update
    void Start()
    {
        portal1.SetActive(false);
        portal2.SetActive(false);
        portal3.SetActive(false);

        touching = false;

        portalActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching && cards1 == null && cards2 == null && cards3 == null)
        {
            Debug.Log("End of Level");
            //LOAD LVL 4
        }

        if(!portalActive && cards1 == null && cards2 == null && cards3 == null)
        {
            portalActive = true;

            portal1.SetActive(true);
            portal2.SetActive(true);
            portal3.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == targetCollider)
        {
            touching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider == targetCollider)
        {
            touching = false;
        }
    }
}
