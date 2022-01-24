using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;


    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false , false);
        controller.Move(verticalMove * Time.fixedDeltaTime, false, false);
    }
}
