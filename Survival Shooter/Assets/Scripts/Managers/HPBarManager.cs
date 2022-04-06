using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBarManager : MonoBehaviour
{
    public static int health;
    public static int maxHealth;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        health = 100;
        maxHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = health + "/" + maxHealth;
    }
}
