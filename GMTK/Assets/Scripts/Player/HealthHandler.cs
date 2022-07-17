using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public static HealthHandler HH;

    public float health;
    public float maxHealth;

    public HealthbarController HPdisplay;

    void Start()
    {
        //makes sure there is only one player movement script
        if (HH == null)
        {
            HH = this;
        }
        else if (HH != this)
        {
            Destroy(gameObject);
        }

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HPdisplay.SetHealth(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void dockHealth(float amount)
    {
        health -= amount;
    }

}
