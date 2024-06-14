using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI killsText;
    [SerializeField] private TextMeshProUGUI waveText;
    public static float health = 100f;
    public static int money = 100;

    public static int totalKills = 0;
    public static int waveCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        healthBar.GetComponentInChildren<TextMeshProUGUI>().text = health + " / 100";

        moneyText.text = "Money: " + money;
        killsText.text = "Total Kills: " + totalKills;
        waveText.text = "Wave: " + waveCount;

        if (health == 0)
            SceneManager.LoadScene("EndScene");
    }
}
