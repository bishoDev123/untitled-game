using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTarget : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());

    }

    // Update is called once per frame
    void Update()
    {
        if (LoyalSpear.LS.thrown)
        {
            transform.position = LoyalSpear.LS.target;
        }
    }
}
