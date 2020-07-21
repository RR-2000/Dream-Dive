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

    public int _health =  4;
    public GameObject _FB;
    public float runSpeed = 10.0f;
    public int no_att_max = 10;
    public int no_att;
    public float jump_vel = 7.0f;

    public static Player player;

    void Awake()
    {
        player = this;
    }

    public float getY(){
      return _T.position.y;
    }
    void Start()
    {
        _RB = gameObject.GetComponent<Rigidbody2D>();
        _T = gameObject.GetComponent<Transform>();
        _anim = gameObject.GetComponent<Animator>();
        no_att = no_att_max;
        EventSystem.current.onEnemyKill += OnEnemyKill;
    }

    void Update(){
      if(Input.GetKeyDown("space")){
        Jump();
      }
      if(_health <= 0){
        EventSystem.current.PlayerDeath();
        Destroy(gameObject);
      }
    }

    void FixedUpdate()
    {

      move(Input.GetAxis("Horizontal"));

    }

    public void move(float inp)
    {
      isMoving = true;
      if(inp > 0){
        _T.localScale = new Vector3(2.5f, 2.5f, 1f);
      }else if(inp < 0){
        _T.localScale = new Vector3(-2.5f, 2.5f, 1f);
      }else{
        isMoving = false;
      }
      _T.position += new Vector3((Time.deltaTime*runSpeed*inp ), 0, 0);

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

      if(col.gameObject.tag == "Enemy"){
        _health--;
        col.gameObject.GetComponent<Enemy>()._health -= 5;
        EventSystem.current.PlayerDamage();
      }
    }

    public void Jump(){
      if(isGrounded){
        _RB.velocity = new Vector3(_RB.velocity.x, jump_vel, 0);
      }else if(no_att > 0){
        _RB.velocity = new Vector3(_RB.velocity.x, jump_vel, 0);
        Instantiate(_FB, new Vector3(_T.position.x, _T.position.y, _T.position.z), _FB.transform.rotation);
        no_att--;
      }
    }

    public void OnEnemyKill(){
      no_att = no_att_max;
    }
}
