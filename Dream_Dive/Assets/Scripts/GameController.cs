using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] list;
    public int no_of_verts = 1;
    private float current_Vert;
    // Start is called before the first frame update
    void Start()
    {
      current_Vert = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if(Player.player == null){
        return;
      }
      if(current_Vert > Player.player.getY() - 5){
        current_Vert -= 10;
        Instantiate(list[Random.Range(0, no_of_verts)], new Vector3(0, current_Vert, 0), Quaternion.identity);
      }
    }
}
