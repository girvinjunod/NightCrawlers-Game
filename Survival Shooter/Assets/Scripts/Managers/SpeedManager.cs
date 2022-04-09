using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedManager : MonoBehaviour
{
    public static float speed;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Speed : " + speed;
    }
}
