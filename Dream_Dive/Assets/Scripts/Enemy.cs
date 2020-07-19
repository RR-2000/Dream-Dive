using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _RB;
    private Transform _T;
    private bool colFlag = true;
    public float _speed = 2f;
    public float _health = 10f;
    void Start()
    {
        _RB = gameObject.GetComponent<Rigidbody2D>();
        _T = gameObject.GetComponent<Transform>();
        _RB.velocity = new Vector3(_speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
      if(_health <= 0){
        EventSystem.current.EnemyKill();
        Destroy(gameObject);
      }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      if(colFlag == true){
        _RB.velocity = new Vector3(-_speed, 0, 0);
        _speed *= -1;
        _T.localScale = new Vector3(-_T.localScale.x, _T.localScale.y, _T.localScale.z);
        colFlag = false;
      }
    }
    void OnCollisionExit2D(Collision2D col)
    {
      if(col.gameObject.tag == "Attack"){

      }else{
        colFlag = true;
      }
    }
}
