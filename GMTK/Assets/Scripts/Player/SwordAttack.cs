using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private BoxCollider2D hb;

    // Start is called before the first frame update
    void Start()
    {
        hb = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputManager.IM.jump))
        {
            hb.enabled = true;
        }
        if (Input.GetKeyUp(InputManager.IM.jump))
        {
            hb.enabled = false;
        }
    }
}
  
