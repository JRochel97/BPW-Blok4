using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartTrigger : MonoBehaviour
{
    public LevelManager levelmanager;

    void OnTriggerEnter2D()
    {
        levelmanager.RestartLevel();
    }
}
