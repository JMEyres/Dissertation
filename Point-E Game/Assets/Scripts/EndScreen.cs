using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stats;
    
    // Start is called before the first frame update
    void Start()
    {
        stats.text = "\n" + PlayerStats.health + "\n" + PlayerStats.money + "\n" + PlayerStats.totalKills;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
