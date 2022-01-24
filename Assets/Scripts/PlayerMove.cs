using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D body;
    GameManager gm;

    float horizontal;
    float vertical;
    public GameObject player;


    public float runSpeed = 20.0f;

    void Start ()
    {

        body = GetComponent<Rigidbody2D>(); 

    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
