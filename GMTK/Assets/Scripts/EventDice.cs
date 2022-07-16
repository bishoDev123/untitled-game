using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDice : MonoBehaviour
{
    public Rigidbody diceR;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;

    public Camera mainCamera;

    float prevTime;
    // Start is called before the first frame update
    void Start()
    {
        prevTime = 0.0f;
    }

    bool checkedAlready = false;
    // Update is called once per frame
    void Update()
    {
        transform.position = mainCamera.transform.position + new Vector3(10.0f, 4.0f, 1.0f);

        Debug.DrawRay(transform.position, transform.rotation * Vector3.forward * 5.0f, Color.white, 0.01f);
        if (Time.time - prevTime >= 0.8f && !checkedAlready)
        {
            checkedAlready = true;
            //halt all previous rotation
            diceR.angularVelocity = Vector3.zero;

            
            //Debug.Log(checkDirection());
        }

        if (Time.time - prevTime >= 1.0f)
        {
            prevTime = Time.time;

            /*
            Ray checker = new Ray();
            checker.direction = new Vector3(0.0f, 0.0f, 1.0f);
            checker.origin = new Vector3(10.0f, 4.0f, -1.0f);

            RaycastHit checkerHit;

            if(Physics.Raycast(checker.direction, checker.origin, out checkerHit))
            {
                Debug.Log(checkerHit.textureCoord);
            }
            Debug.DrawRay(checker.origin, checker.direction * 10.0f, Color.white, 10.0f);
            */


            //start a new dice rotation
            diceR.AddTorque(Random.onUnitSphere * 10.0f);

            checkedAlready = false;
        }
    }

    float checkDirection()
    {
        
        Vector3 direction = transform.rotation * Vector3.forward;

        Vector3 camD = new Vector3(0.0f, 0.0f, 1.0f);


        float dotUp = Vector3.Dot(Vector3.up, direction);
        float dotRight = Vector3.Dot(Vector3.right, direction);
        float dotForward = Vector3.Dot(Vector3.forward, direction);


        float best = Mathf.Max(Mathf.Max(Mathf.Abs(dotUp), Mathf.Abs(dotRight)), Mathf.Abs(dotForward));
        float option;

        float saveZRotation = Mathf.Floor(transform.rotation.eulerAngles.z / 90.0f) * 90.0f;

        if(Mathf.Abs(dotRight) == best)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right * Mathf.Sign(dotRight));
            option = 1.0f * Mathf.Sign(dotRight);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, saveZRotation);
        }
        else if (Mathf.Abs(dotUp) == best)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.up * Mathf.Sign(dotUp));
            option = 2.0f * Mathf.Sign(dotUp);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, saveZRotation);

        }
        else
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward * Mathf.Sign(dotForward));
            option = 3.0f * Mathf.Sign(dotForward);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, saveZRotation);

        }


        Ray checker = new Ray();
        checker.direction = new Vector3(0.0f, 0.0f, 1.0f);
        checker.origin = transform.position - new Vector3(0.0f, 0.0f, 3.0f);

        RaycastHit checkerHit;

        if (Physics.Raycast(checker.origin, checker.direction * 10.0f, out checkerHit))
        {
            
            if(checkerHit.collider.gameObject == one)
            {
                return 1.0f;
            }
            if (checkerHit.collider.gameObject == two)
            {
                return 2.0f;
            }
            if (checkerHit.collider.gameObject == three)
            {
                return 3.0f;
            }
            if (checkerHit.collider.gameObject == four)
            {
                return 4.0f;
            }
            if (checkerHit.collider.gameObject == five)
            {
                return 5.0f;
            }
            if (checkerHit.collider.gameObject == six)
            {
                return 6.0f;
            }
        }
        Debug.DrawRay(checker.origin, checker.direction * 10.0f, Color.red, 10.0f);


        return 0.0f;

    }
}
