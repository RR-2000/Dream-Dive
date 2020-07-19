using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Transform _T;

    public float attack_speed = 8.0f;
    public float damage = 5;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -attack_speed, 0);
        _T = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(_T.position.y < Player.player.getY() - 10){
        Destroy(gameObject);
      }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.tag == "Enemy"){
        col.gameObject.GetComponent<Enemy>()._health -= damage;
      }
      if(col.gameObject.tag != "Player"){
        Destroy(gameObject);
      }
    }
}
