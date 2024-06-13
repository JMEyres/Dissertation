using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject controls;

    private bool controlsToggle = false;
    
    public void StartGame()
    {
        SceneManager.LoadScene("TDGame");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void How2Play()
    {
        controlsToggle = !controlsToggle;
        image.SetActive(!controlsToggle);
        controls.SetActive(controlsToggle);
    }
}
