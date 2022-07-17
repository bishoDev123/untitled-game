using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Program has been exited");
        Application.Quit();
    }
}