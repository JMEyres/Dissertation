using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject controls;
    [SerializeField] private AudioSource clickSound;
    
    private bool controlsToggle = false;

    private void Start()
    {
        if (clickSound == null) clickSound = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        clickSound.Play();
        SceneManager.LoadScene("TDGame");
    }
    
    public void ExitGame()
    {
        clickSound.Play();
        Application.Quit();
    }

    public void How2Play()
    {
        clickSound.Play();
        controlsToggle = !controlsToggle;
        image.SetActive(!controlsToggle);
        controls.SetActive(controlsToggle);
    }
}
