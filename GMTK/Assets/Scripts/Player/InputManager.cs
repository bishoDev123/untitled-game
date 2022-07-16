using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    //arrays containing the keycodes, the key names, and the system key names
    public List<KeyCode> keys;
    public string[] keysN = new string[14];
    public string[] keysSysN = new string[14];

    //the different keybindings
    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode up { get; set; }
    public KeyCode down { get; set; }
    public KeyCode jump { get; set; }
    public KeyCode crouch { get; set; }
    public KeyCode MBOne { get; set; }
    public KeyCode MBTwo { get; set; }
    public KeyCode one { get; set; }
    public KeyCode two { get; set; }
    public KeyCode three { get; set; }
    public KeyCode four { get; set; }
    public KeyCode five { get; set; }
    public KeyCode six { get; set; }

    public KeyCode[,] diceOptions { get; set; }

    public KeyCode use { get; set; }
    public KeyCode sprint { get; set; }
   

    public float mouseSensitivity { get; set; }
    public float shipSensitivity { get; set; }

    public string movementMode { get; set; }
    void Awake()
    {

        PlayerPrefs.DeleteAll();

        //makes sure there is only one input manager script
        if (IM == null)
        {
            IM = this;
        }
        else if (IM != this)
        {
            Destroy(gameObject);
        }

        movementMode = "player";



        //do the mouse sensistivity
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 1.0f);

        //create the keycodes for the player preference keybindings (if they don't exist yet then set to defaults)
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardBind", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardBind", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftBind", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightBind", "D"));
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upBind", "LeftShift"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downBind", "LeftControl"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpBind", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchBind", "C"));
        MBOne = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MBOneBind", "Mouse0"));
        MBTwo = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MBTwoBind", "Mouse1"));


        one = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("oneBind", "Alpha1"));
        two = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("twoBind", "Alpha2"));
        three = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("threeBind", "Alpha3"));
        four = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fourBind", "Alpha4"));
        five = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fiveBind", "Alpha5"));
        six = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sixBind", "Alpha6"));

        use = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useBind", "E"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sprintBind", "LeftShift"));
        


        //makes an array of all of the keys
        keys = new List<KeyCode> { forward, backward, left, right, up, down, jump, crouch, MBOne, MBTwo, one, two, three, use, sprint };

        //if you add another key make sure to increase the array size at the top (yes I said "you" to myself)
        keysN = new string[] { "forward", "backward", "left", "right", "up", "down", "jump", "crouch", "MBOne", "MBTwo", "one", "two", "three", "four", "five", "six", "use", "sprint" };
        keysSysN = new string[] { "forwardBind", "backwardBind", "leftBind", "rightBind", "upBind", "downBind", "jumpBind", "crouchBind", "MBOneBind", "MBTwoBind", "oneBind", "twoBind", "threeBind", "fourBind", "fiveBind", "sixBind", "useBind", "sprintBind" };



        diceOptions = new KeyCode[,] { { three, four, five, six }, { one, three, four, six }, { one, two, five, six }, { one, two, five, six }, { one, three, four, six }, { two, three, four, five } };


        

    }


    private void Start()
    {

    }

    public bool anyPressed { get; set; }
    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    void Update()
    {



    }



    public void refreshBinds()
    {
        //refresh the look sensitivity
        mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity", 1.0f);

        //reload the key bindings after a binding change
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardBind", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardBind", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftBind", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightBind", "D"));
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upBind", "LeftShift"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downBind", "LeftControl"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpBind", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouchBind", "C"));
        MBOne = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MBOneBind", "Mouse0"));
        MBTwo = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MBTwoBind", "Mouse1"));

        one = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("oneBind", "Alpha1"));
        two = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("twoBind", "Alpha2"));
        three = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("threeBind", "Alpha3"));
        four = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fourBind", "Alpha4"));
        five = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("fiveBind", "Alpha5"));
        six = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sixBind", "Alpha6"));
        use = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("useBind", "E"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sprintBind", "LeftShift"));
        
    }


}


