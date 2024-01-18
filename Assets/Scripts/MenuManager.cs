using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void ClassicLevel()
    {
        SceneManager.LoadScene("Classic");
    }

    public void ControlLevel()
    {
        Debug.Log("Controls");
    }

    public void QuitLevel()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
