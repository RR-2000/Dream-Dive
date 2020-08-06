using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public Sprite[] li;

    void Start()
    {
      EventSystem.current.onPlayerDamage += health_update;
    }

    void health_update()
    {
      GetComponent<Image>().sprite = li[Player.player.getHealth()];
    }
}
