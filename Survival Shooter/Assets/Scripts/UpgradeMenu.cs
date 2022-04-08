using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeMenu : MonoBehaviour
{
    public static bool IsUpgradeNow = false;

    public GameObject UpgradeMenuUI;
    public GameObject UpgradeOption1; // diagonal bullets
    public GameObject UpgradeOption2; // atk speed
    public GameObject UpgradeOption3; //piercing

    public TextMeshProUGUI UpgradeOption1Counter;
    public TextMeshProUGUI UpgradeOption2Counter;
    public TextMeshProUGUI UpgradeOption3Counter;


    public WaveManager waveManager;
    float time = 0;
    private int counter1 = 0;
    private int counter2 = 0;
    private int counter3 = 0;

    private int maxCounter1 = 2;
    private int maxCounter2 = 2;
    private int maxCounter3 = 2;

    private int numUpgrades = 0;
    private int maxNumUpgrades = 6;

    private int perTime = 10;

    // void Awake()
    // {
    //     time = 0;
    //     Time.timeScale = 0f;
    // }

    // void OnEnable()
    // {
    //     // Time.timeScale = 0f;
    //     // IsUpgradeNow = true;
    // }

    // Update is called once per frame
    void Update()
    {
        // StateHolder.GameMode = "ZenMode";
        if (numUpgrades != maxNumUpgrades && !StateHolder.isGameOver)
        {
            if (StateHolder.GameMode == "ZenMode")
            {
                time += (1 * Time.deltaTime);
                // Debug.Log(time);
                if ((int)time % perTime == 0 && (int)time > 0 && (int)time / perTime == numUpgrades + 1)
                {
                    Pause();
                }
            }
            else if (StateHolder.GameMode == "WaveMode")
            {
                if (waveManager.currentWave % 3 == 1 && waveManager.currentWave != 1 && (waveManager.currentWave - 1) / 3 == numUpgrades + 1)
                {
                    Pause();
                }
            }
        }
    }

    void Pause()
    {
        UpgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsUpgradeNow = true;
    }

    void Resume()
    {
        UpgradeMenuUI.SetActive(false);
        IsUpgradeNow = false;
        numUpgrades++;
        if (counter1 >= maxCounter1)
        {
            UpgradeOption1.GetComponent<Button>().interactable = false;
        }
        if (counter2 >= maxCounter2)
        {
            UpgradeOption2.GetComponent<Button>().interactable = false;
        }
        if (counter3 >= maxCounter3)
        {
            UpgradeOption3.GetComponent<Button>().interactable = false;
        }
        Time.timeScale = 1f;
    }

    public void Option1()
    {
        counter1++;
        UpgradeOption1Counter.text = counter1 + "/" + maxCounter1;
        Debug.Log("Upgrade 1");
        Resume();
    }

    public void Option2()
    {
        counter2++;
        UpgradeOption2Counter.text = counter2 + "/" + maxCounter2;
        Debug.Log("Upgrade 2");
        Resume();
    }

    public void Option3()
    {
        counter3++;
        UpgradeOption3Counter.text = counter3 + "/" + maxCounter3;
        Debug.Log("Upgrade 3");

        PlayerShooting.critChance += 15;

        Resume();
    }
}
