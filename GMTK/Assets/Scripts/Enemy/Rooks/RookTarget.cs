using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookTarget : MonoBehaviour
{
    public float dashDistance;
    public float squarePlaceDuration;
    

    //private Rigidbody2D rb;
    //private LineRenderer lr;
    private Vector3 dashStart;
    private Vector3 dashEnd;
    private Vector3 dir;
    private float pointAng;

    public float squareStep;

    private float currentSquare;
    private float numberOfSquares;

    private GameObject[] squares;

    private bool started;

    private float squarePlaceDelay;
    private float prevPlaceTime;
    // Start is called before the first frame update
    void Start()
    {
        currentSquare = 0.0f;
        numberOfSquares = (float)(int)(dashDistance / squareStep);
        squares = new GameObject[(int)numberOfSquares];

        squarePlaceDelay = squarePlaceDuration / numberOfSquares;

        
        transform.position = this.gameObject.GetComponentInParent<Transform>().position;
        //rb = gameObject.GetComponent<Rigidbody2D>();
        //lr = gameObject.GetComponent<LineRenderer>();

        dashStart = transform.position;
        dashEnd = PlayerMovement.PM.playerGameObject.transform.position;

        dir = (dashEnd - dashStart).normalized;

        //angle that the spear should point towards (the player)
        pointAng = Mathf.Atan2(dir.y, dir.x);
        //point the spear at the player
        transform.rotation = Quaternion.Euler(0f, 0f, (pointAng * Mathf.Rad2Deg) - 90);

        transform.position += dir * squareStep;

        started = false;

        prevPlaceTime = 0.0f;
        //transform.position += dir * squareSize;

        /*
        rb.velocity = new Vector2(dir.x, dir.y) * 20.0f;

        Vector3[] pos = new Vector3[(int)(dashDistance / arrowSize)];


        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = dashStart + (dir * (float)i * arrowSize);
            Debug.Log(Vector3.Distance(dashStart, pos[i]));
            
        }
        

        lr.SetPositions(pos);

        lr.material.mainTextureScale = new Vector2(dashDistance * 20.0f, 1.0f); ;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = Vector2.zero;

        if(currentSquare < numberOfSquares)
        {
            if(Time.time - prevPlaceTime > squarePlaceDelay)
            {
                if (currentSquare % 2.0f == 0.0f)
                {
                    squares[(int)currentSquare] = Instantiate(Dealer.CardMaster.whiteSquare, dashStart + (dir * (currentSquare + 1.0f) * squareStep), transform.rotation);
                    squares[(int)currentSquare].SetActive(true);
                    squares[(int)currentSquare].transform.localScale = new Vector3(squareStep, squareStep, 1.0f);

                    //transform.position += dir * squareSize;

                }
                else
                {

                    squares[(int)currentSquare] = Instantiate(Dealer.CardMaster.blackSquare, dashStart + (dir * (currentSquare + 1.0f) * squareStep), transform.rotation);
                    squares[(int)currentSquare].SetActive(true);
                    squares[(int)currentSquare].transform.localScale = new Vector3(squareStep, squareStep, 1.0f);

                    //transform.position += dir * squareSize;
                }

                prevPlaceTime = Time.time;

                currentSquare += 1.0f;
            }
            
        }
        else
        {
            for (int i = 0; i < numberOfSquares; i++)
            {
                this.gameObject.GetComponentInParent<Rook>().SendMessage("startDash");
                started = true;
                Destroy(squares[i]);
            }
            Destroy(gameObject);
        }
        

        /*
        if(Vector3.Distance(dashStart, transform.position) >= dashDistance && !started)
        {
            started = true;

            rb.velocity = Vector2.zero;

            this.gameObject.GetComponentInParent<Rook>().SendMessage("startDash");
            Destroy(gameObject);
        }
        */
    }
}
