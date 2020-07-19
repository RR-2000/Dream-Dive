using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class health_FB_Text : MonoBehaviour
{
    public Text tx;
    public Text Score;

    private int score = 0;

    void Start(){
      EventSystem.current.onEnemyKill += score_up;
      EventSystem.current.onPlayerDeath += score_disp;
    }

    void Update()
    {
      tx.text = "Health: " + Player.player._health.ToString() + " Fire Balls: " + Player.player.no_att.ToString();
    }

    void score_up(){
      score++;
    }

    void score_disp(){
      Score.text = "Score: " + score.ToString();
    }
}
