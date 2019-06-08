using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Quit(int level)
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}