using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public static Dealer CardMaster;

    public GameObject cardHolder;
    public GameObject cardMissile;

    private float prevSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        cardHolder.SetActive(false);
        cardMissile.SetActive(false);

        //makes sure there is only one player movement script
        if (CardMaster == null)
        {
            CardMaster = this;
        }
        else if (CardMaster != this)
        {
            Destroy(gameObject);
        }


        GameObject temp = Instantiate(cardHolder);
        temp.SetActive(true);

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


    public void requestLaunch(int quantity, Transform cardHolderTransform)
    {
        for(int i = 0; i < quantity; i++)
        {
            GameObject temp = Instantiate(cardMissile, cardHolderTransform);
            temp.SetActive(true);
        }
    }
}
