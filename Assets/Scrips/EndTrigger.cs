using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public LevelManager levelmanager;

    void OnTriggerEnter2D()
    {
        levelmanager.CompleteLevel();   
    }
}
