using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{

    private float rotang;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        rotang = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerMovement.PM.transform.position + new Vector3(Mathf.Cos(rotang), Mathf.Sin(rotang)) * distance;


        rotang += 2.0f * Time.deltaTime;
    }
}
