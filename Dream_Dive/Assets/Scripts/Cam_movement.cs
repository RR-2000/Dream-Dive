using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_movement : MonoBehaviour
{
    public Transform _T, Player_T;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player_T == null){
          return;
        }
        if(_T.position.y > Player_T.position.y){
          _T.position = new Vector3(_T.position.x, Player_T.position.y, _T.position.z);
        }
    }
}
