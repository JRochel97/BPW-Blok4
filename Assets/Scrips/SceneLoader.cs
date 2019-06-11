using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject EndLevelUI;

    public void Quit(int level)
    {
        StartCoroutine(Quit());
    }

    public void LoadScene(int level)
    {
        StartCoroutine(StartLevel());
    }

    IEnumerator Quit()
    {
        EndLevelUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
        Debug.Log("Quit Game");
    }

    IEnumerator StartLevel()
    {
        EndLevelUI.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}