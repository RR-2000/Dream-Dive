using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    private Image fireBar;

    void Start()
    {
      fireBar = GetComponent<Image>();
    }

    void Update()
    {
      if(Player.player == null){
        return;
      }
      fireBar.fillAmount = Player.player.no_att/(float)Player.player.no_att_max;
    }
}
