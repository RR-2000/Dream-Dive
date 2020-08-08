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
    public bool jump_dmg = false;
    public bool Grounded =  false;

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
      if(Player.player == null){
        return;
      }
      if(Grounded && _T.position.y < Player.player.getY() - 30){
        Destroy(gameObject);
      }
    }

    void FixedUpdate(){
      if(Grounded){
        _RB.velocity = new Vector3(_speed, _RB.velocity.y, 0);
      }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
      if(Grounded && col.gameObject.tag == "Ground"){
        return;
      }
      if(colFlag == true ){
        _RB.velocity = new Vector3(-_speed, 0, 0);
        _speed *= -1;
        _T.localScale = new Vector3(-_T.localScale.x, _T.localScale.y, _T.localScale.z);
        colFlag = false;
      }
    }
    void OnCollisionExit2D(Collision2D col)
    {
      if(Grounded && col.gameObject.tag == "Ground"){
        return;
      }

      if(col.gameObject.tag == "Attack"){

      }else{
        colFlag = true;
      }
    }
}
