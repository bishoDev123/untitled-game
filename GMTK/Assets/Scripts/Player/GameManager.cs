using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public int diceUp { get; set; }
    public int diceBack { get; set; }

    public float[,] diceOptions { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        //makes sure there is only one game manager script
        if (GM == null)
        {
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }


        diceOptions = new float[,] { { 3f, 4f, 5f, 6f }, { 1f, 3f, 4f, 6f }, { 1f, 2f, 5f, 6f }, { 1f, 2f, 5f, 6f }, { 1f, 3f, 4f, 6f }, { 2f, 3f, 4f, 5f } };


        rollDie();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void rollDie()
    {
        diceUp = (int)Mathf.Floor(Random.Range(0.0f, 6.0f)) + 1;
        //Debug.Log(diceUp);
        diceBack = (int)diceOptions[diceUp - 1, (int)Mathf.Floor(Random.Range(0.0f, 4.0f))];
    }

}
