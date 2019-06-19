using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public GameObject completeLevelUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            StartCoroutine(Escape());
        }
    }

    public void CompleteLevel()
    {
        StartCoroutine(Complete());
    }

    public void RestartLevel()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        completeLevelUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator Complete()
    {
        completeLevelUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Escape()
    {
        completeLevelUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }
}
