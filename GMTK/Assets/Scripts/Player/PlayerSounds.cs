using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip diceRoll1;
    public AudioClip diceRoll2;
    public AudioClip diceRoll3;
    public AudioClip diceRoll4;
    public AudioClip diceRoll5;

    public AudioSource playerAudioSource;
    public AudioDistortionFilter playerDistorter;
    public AudioReverbFilter playerReverber;


    private AudioClip[] noises;
    // Start is called before the first frame update
    void Start()
    {
        noises = new AudioClip[5];
        noises[0] = diceRoll1;
        noises[1] = diceRoll2;
        noises[2] = diceRoll3;
        noises[3] = diceRoll4;
        noises[4] = diceRoll5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputManager.IM.left) || Input.GetKeyDown(InputManager.IM.right) || Input.GetKeyDown(InputManager.IM.forward) || Input.GetKeyDown(InputManager.IM.backward))
        {
            //playerReverber.reverbPreset = (AudioReverbPreset)((int)Random.Range(0.0f, 26.99f));
            //playerDistorter.distortionLevel = Random.value;

            int coinFlip = (int)Random.Range(0.0f, 4.99f);

            playerAudioSource.PlayOneShot(noises[coinFlip]);
        }
    }
}
