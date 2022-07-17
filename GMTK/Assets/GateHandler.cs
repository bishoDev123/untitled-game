using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour
{
    private LevelHandler open;

    private void Update()
    {
        if (open.killedAllEnemies)
            Destroy(gameObject);
    }
}
