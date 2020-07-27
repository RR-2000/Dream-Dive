using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verts : MonoBehaviour
{
    private Transform _T;

    void Start()
    {
        _T = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Player.player == null || _T.position.y > Player.player.getY() + 15){
        Destroy(gameObject);
      }
    }
}
