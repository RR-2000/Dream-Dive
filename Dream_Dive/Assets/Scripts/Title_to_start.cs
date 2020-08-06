using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_to_start : MonoBehaviour
{
    public MonoBehaviour camMove;
    public MonoBehaviour gameController;
    public MonoBehaviour beginVert;
    public GameObject plyr;

    public void BEGIN(){
      Instantiate(plyr, new Vector3(0, 8, 0), Quaternion.identity);
      EventSystem.current.PlayerSpawn();
      camMove.enabled = true;
      gameController.enabled = true;
      beginVert.enabled = true;
      Destroy(gameObject);
    }
}
