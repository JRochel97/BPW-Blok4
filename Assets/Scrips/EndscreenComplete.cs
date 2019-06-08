using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndscreenComplete : MonoBehaviour
{
    public void BacktoTheBeginnin()
    {
        SceneManager.LoadScene("Menu");
    }
}
