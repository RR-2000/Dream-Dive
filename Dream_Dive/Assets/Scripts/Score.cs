using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text sc;

    private int score = 0;
    private float timeUP;
    private float score_mult;
    private Color cl;
    void Start(){
      EventSystem.current.onEnemyKill += score_up;
      EventSystem.current.onPlayerDeath += score_disp;
      EventSystem.current.onPlayerSpawn += setMult;
    }

    void Update(){
      if(Player.player == null){
        return;
      }else if (Player.player.getGrounded()){
        setMult();
      }else{
        timeUP += Time.deltaTime;
        score_mult += Time.deltaTime;
        cl = new Color(Mathf.Clamp01(timeUP/10),Mathf.Clamp01((timeUP-8)/10),Mathf.Clamp01((timeUP-16)/10),1);
        Player.player.setTrailStart(cl);
      }
    }

    void setMult(){
      score_mult = 1;
      timeUP = 0;
    }
    void score_up(){
      score += Mathf.Clamp((int)score_mult, 1, 20);
    }

    void score_disp(){
      sc.text = "Score: " + score.ToString();
    }
}
