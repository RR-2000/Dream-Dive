using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _RB;
    private Transform _T;
    private bool isGrounded = false;
    private bool isMoving = false;
    private SpriteRenderer  _SR;
    private Color nrml_color = new Color(1,1,1,1);
    private Color dmg_color = new Color(1,0,0,0.75f);

    public int _health =  4;
    public GameObject _FB;
    public float runSpeed = 10.0f;
    public int no_att_max = 10;
    public int no_att;
    public float jump_vel = 7.0f;
    public float dmg_color_speed = 10f;

    public static Player player;

    void Awake()
    {
        player = this;
    }

    void Start()
    {
        _RB = gameObject.GetComponent<Rigidbody2D>();
        _T = gameObject.GetComponent<Transform>();
        _anim = gameObject.GetComponent<Animator>();
        _SR = gameObject.GetComponent<SpriteRenderer>();
        no_att = no_att_max;
        EventSystem.current.onEnemyKill += OnEnemyKill;
        EventSystem.current.onPlayerDamage += onDamage;
    }

    public int getHealth(){
      return _health;
    }

    void Update(){
      if(Input.GetKeyDown("space")){
        Jump();
      }
      if(_health <= 0){
        EventSystem.current.PlayerDeath();
        Destroy(gameObject);
      }
      _SR.color = Color.Lerp(_SR.color, nrml_color, dmg_color_speed * Time.deltaTime);
    }

    void FixedUpdate()
    {

      move(Input.GetAxis("Horizontal"));
      if(Input.acceleration.x > 0.1 || Input.acceleration.x < -0.1){
        move(Input.acceleration.x*3);
      }
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



      if(col.collider.tag == "Enemy_Head"){
        col.gameObject.GetComponentInParent<Enemy>()._health -= 5;
        if(col.gameObject.GetComponentInParent<Enemy>().jump_dmg){
          EventSystem.current.PlayerDamage();
        }
        _RB.velocity = new Vector3(_RB.velocity.x, jump_vel, 0);
        return;
      }

      if(col.gameObject.tag == "Enemy"){
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

    public float getY(){
      return _T.position.y;
    }

    public void onDamage(){
      _health--;
      _SR.color = dmg_color;
    }
}
