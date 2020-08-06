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
      EventSystem.current.onPlayerDeath += health_update;
    }

    void health_update()
    {
      if(Player.player.getHealth() <= 0){
        GetComponent<Image>().sprite = li[0];
      }else{
        GetComponent<Image>().sprite = li[Player.player.getHealth()];
      }
    }
}
