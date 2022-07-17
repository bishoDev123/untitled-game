using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAway : MonoBehaviour
{
    public Transform player;

    private EnemyController ec;

    private Vector2 distance;

    private void Start()
    {
        ec = GetComponent<EnemyController>();
    }

    private void Update()
    {
        distance = transform.position - player.transform.position;

        if(distance.y >= 10)
        {
            ec.enabled = false;
        }
        else
        {
            ec.enabled = true;
        }
    }
}
