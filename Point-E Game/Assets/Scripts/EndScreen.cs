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
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        clickSound.Play();
        Application.Quit();
    }
}
