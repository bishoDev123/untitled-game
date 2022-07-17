using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{



    int enemiesLeft = 0;
    public bool killedAllEnemies = false;
    void Start()
    {
        enemiesLeft = 10; // or whatever;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemiesLeft = enemies.Length;
        if (Input.GetKeyDown(KeyCode.A))
        {
            enemiesLeft--;
        }
        if (enemiesLeft == 0)
        {
            endGame();
        }
        if (killedAllEnemies)
            Destroy(GameObject.Find("Gate"));
    }

    void endGame()
    {
        killedAllEnemies = true;
    }
}
