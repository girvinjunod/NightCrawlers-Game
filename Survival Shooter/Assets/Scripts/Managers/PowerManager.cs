using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerManager : MonoBehaviour
{
  // Start is called before the first frame update
  // protected PlayerShooting playerShooting;
  // GameObject player;
  public static int power;

  Text text;
  void Awake()
  {
    // player = GameObject.FindGameObjectWithTag("Player");
    // playerShooting = player.GetComponent<PlayerShooting>();
    text = GetComponent<Text>();
    power = 0;
  }

  // Update is called once per frame
  void Update()
  {
    text.text = "Power : " + power;
    // print(playerShooting.damagePerShot);
  }
}
