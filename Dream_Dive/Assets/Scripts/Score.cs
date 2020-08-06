using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text sc;

    private int score = 0;
    private float timeUP = 0;
    private int score_mult = 0;

    void Start(){
      EventSystem.current.onEnemyKill += score_up;
      EventSystem.current.onPlayerDeath += score_disp;
      EventSystem.current.onPlayerSpawn += setMult;
    }

    void setMult(){
      score_mult = 1;
    }
    void score_up(){
      score += score_mult;
    }

    void score_disp(){
      sc.text = "Score: " + score.ToString();
    }
}
