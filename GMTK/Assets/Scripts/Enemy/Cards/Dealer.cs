using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public static Dealer CardMaster;

    public GameObject cardHolder;
    public GameObject cardMissile;
    public GameObject knight;

    private float prevSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        //make the originals not actually do anything
        cardHolder.SetActive(false);
        cardMissile.SetActive(false);
        knight.SetActive(false);

        //makes sure there is only one player movement script
        if (CardMaster == null)
        {
            CardMaster = this;
        }
        else if (CardMaster != this)
        {
            Destroy(gameObject);
        }

        //create one card holder at the start
        GameObject temp = Instantiate(cardHolder);
        temp.SetActive(true);

        //create one card holder at the start
        temp = Instantiate(knight);
        temp.SetActive(true);

        //the spawner timer
        prevSpawnTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
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
