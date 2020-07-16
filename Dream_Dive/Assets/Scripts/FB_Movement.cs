using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB_Movement : MonoBehaviour
{
    public float attack_speed = 8.0f;
    public float damage = 5;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -attack_speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
