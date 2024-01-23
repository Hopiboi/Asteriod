using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [Header("Control Menu")]
    [SerializeField] private int menuCounter = 0;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject controls;

    public void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Levelling
    public void ClassicLevel()
    {
        SceneManager.LoadScene("Classic");
    }

    public void WalllessLevel()
    {
        SceneManager.LoadScene("Wall-less");
    }

    public void Coop()
    {
        SceneManager.LoadScene("TwoPlayer");
    }

    // Control Menu
    public void ControlLevel()
    {
        menuCounter = 1;
    }

    public void QuitLevel()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    //condition
    public void MenuCondition()
    {
        if (menuCounter == 1 && Input.GetKeyDown(KeyCode.X))
        {
            menu.SetActive(true);
            controls.SetActive(false);
            menuCounter = 0;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
