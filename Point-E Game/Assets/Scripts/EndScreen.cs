using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
    [SerializeField] private AudioSource clickSound;

    
    // Start is called before the first frame update
    void Start()
    {
        if (clickSound == null) clickSound = GetComponent<AudioSource>();
        stats.text = "\n" + PlayerStats.health + "\n" + PlayerStats.money + "\n" + PlayerStats.totalKills;
    }

    public void RestartGame()
    {
        clickSound.Play();
        PlayerStats.health = 100;
        PlayerStats.money = 100;
        PlayerStats.totalKills = 0;
        PlayerStats.waveCount = 0;
        PlayerStats.currentWave = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        clickSound.Play();
        Application.Quit();
    }
}
