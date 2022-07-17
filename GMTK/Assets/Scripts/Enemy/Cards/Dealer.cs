using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public static Dealer CardMaster;

    public GameObject cardHolder;
    public GameObject cardMissile;
    public GameObject knight;
    public GameObject rook;
    public GameObject rookTarget;
    public GameObject whiteSquare;
    public GameObject blackSquare;

    private float prevSpawnTime;


    private GameObject[] enemyTypes;

    private float[,] spawnAgenda;
    private bool[] spawned;

    private GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        //make the originals not actually do anything
        cardHolder.SetActive(false);
        cardMissile.SetActive(false);
        knight.SetActive(false);
        rook.SetActive(false);
        rookTarget.SetActive(false);
        whiteSquare.SetActive(false);
        blackSquare.SetActive(false);

        /*
        enemyTypes = new GameObject[3];

        enemyTypes[0] = cardHolder;
        enemyTypes[1] = knight;
        enemyTypes[2] = rook;

        //for each spawn, do: x, y, time, type, quantity
        spawnAgenda = new float[,] { {10.0f, 10.0f, 2.0f, 1f, 1f } };

        spawned = new bool[spawnAgenda.Length];
        for(int i = 0; i < spawned.Length; i++)
        {
            spawned[i] = false;
        }
        */

        //makes sure there is only one player movement script
        if (CardMaster == null)
        {
            CardMaster = this;
        }
        else if (CardMaster != this)
        {
            Destroy(gameObject);
        }

        /*
        //create one card holder at the start
        temp = Instantiate(cardHolder);
        temp.SetActive(true);

        //create one card holder at the start
        temp = Instantiate(knight);
        temp.SetActive(true);

        temp = Instantiate(rook);
        temp.SetActive(true);
        */

        //the spawner timer
        prevSpawnTime = 0.0f;
    }



    // Update is called once per frame
    void Update()
    {
        /*
        for(int i = 0; i < spawnAgenda.Length; i++)
        {
            if(Time.time >= spawnAgenda[i, 3] && !spawned[i])
            {
                int type = (int)spawnAgenda[i, 3];
                for(int u = 0; u < (int)spawnAgenda[i, 4]; i++)
                {
                    Vector3 variation = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, -2f), 0f) * (float)u;
                    temp = Instantiate(enemyTypes[type], new Vector3(spawnAgenda[i, 0], spawnAgenda[i, 1], 0.0f) + variation, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
                    temp.SetActive(true);
                    spawned[i] = true;
                }
            }
        }
        */


        /*
        if(Time.time - prevSpawnTime > 15.0f){
            GameObject temp = Instantiate(cardHolder);
            temp.SetActive(true);

            prevSpawnTime = Time.time;
        }
        */
    }


    //if a card holder enemy wants to launch some cards then they're created here so that their game objects can be activated
    public void requestLaunch(int quantity, Transform cardHolderTransform)
    {
        for(int i = 0; i < quantity; i++)
        {
            GameObject temp = Instantiate(cardMissile, cardHolderTransform);
            temp.SetActive(true);
        }
    }
}
