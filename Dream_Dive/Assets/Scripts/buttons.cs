using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
    bool _left =  false;
    bool _right = false;
    int mv = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        if(_left == false && _right == false){
          mv = 0;
        }
        if(Player.player != null){
          Player.player.move(mv);
        }
    }

    public void right_dw(){
      _right = true;
      mv = 1;
    }

    public void left_dw(){
      _left = true;
      mv = -1;
    }

    public void right_up(){
      _right = false;
      mv = 1;
    }

    public void left_up(){
      _left = false;
      mv = -1;
    }
}
