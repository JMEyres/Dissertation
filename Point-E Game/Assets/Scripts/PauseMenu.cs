using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject controls;
    [SerializeField] private AudioSource clickSound;

    private bool toggle = false;
    private bool controlsToggle = false;

    private void Start()
    {
        if (clickSound == null) clickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            if (toggle) Time.timeScale = 0;
            if (!toggle) Time.timeScale = 1;
            pauseMenu.SetActive(toggle);
        }
    }

    public void Resume()
    {
        clickSound.Play();
        Time.timeScale = 1;
        toggle = !toggle;
        pauseMenu.SetActive(toggle);
    }

    public void How2Play()
    {
        clickSound.Play();
        controlsToggle = !controlsToggle;
        controls.SetActive(controlsToggle);
    }

    public void Exit()
    {
        clickSound.Play();
        SceneManager.LoadScene("EndScene");
    }

}
