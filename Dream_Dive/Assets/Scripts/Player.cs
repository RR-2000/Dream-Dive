using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _RB;
    private Transform _T;
    private bool isGrounded = true;
    private bool isMoving = false;

    public float runSpeed = 10.0f;
    void Start()
    {
        _RB = gameObject.GetComponent<Rigidbody2D>();
        _T = gameObject.GetComponent<Transform>();
        _anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      isMoving = true;
      if(Input.GetAxis("Horizontal") > 0){
        _T.localScale = new Vector3(2.5f, 2.5f, 1f);
      }else if(Input.GetAxis("Horizontal") < 0){
        _T.localScale = new Vector3(-2.5f, 2.5f, 1f);
      }else{
        isMoving = false;
      }
      _T.position += new Vector3((Time.deltaTime*runSpeed*Input.GetAxis("Horizontal") ), 0, 0);

      _anim.SetBool("Grounded", isGrounded);
      _anim.SetBool("Moving", isMoving);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
      if(col.gameObject.tag == "Ground"){
        isGrounded = false;
      }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.tag == "Ground"){
        isGrounded = true;
      }
    }
}
