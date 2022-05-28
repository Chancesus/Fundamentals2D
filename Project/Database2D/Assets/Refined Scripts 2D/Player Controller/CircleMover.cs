using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    //Initialize adjustable variables
    [SerializeField] float rollSpeed = 10;
    [SerializeField] float jumpVelocity = 10;
    [Tooltip("# of Jumps after Initial")]
    [SerializeField] int extraJumps;


    //Initialize IsGrounded Variables
    [SerializeField] Transform feet;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckSize = 0.5f;

    //Initialize private Rigidbody, Horizontal Input, jumps, and postion
    private Rigidbody2D circleRigid;
    private float horizontal;
    private int currentJumps;
    private Vector2 startingPosition;

    void Start()
    {
        //Get Rigidbody Component from Unity 
        circleRigid = GetComponent<Rigidbody2D>();
        //Set jumps
        currentJumps = extraJumps;
        //Set Player respawn point
        startingPosition = transform.position;
    }

  
    void Update()
    {
        //Define Horizontal
        horizontal = Input.GetAxis("Horizontal");

        //Check if Grounded and Reset jumps
        IsGrounded();

        //Check Input for Jump using Input Manager and currentJumps
        if (Input.GetButtonDown("Jump") && currentJumps != 0)
        {
            Jump();
        }
       
    }
    
    private void FixedUpdate()
    {
        //Fixes jump bug where you stick, use new vector not vector.right or vector.up
        //Set up Horizontal Movement
        circleRigid.velocity = new Vector2(horizontal * rollSpeed, circleRigid.velocity.y);
    }
    

    //Set Up Jump using new Vector 2(fixed x, jumpVelcoity) then assign to rigidbody
    private void Jump()
    {
       Vector2 jump = new Vector2(circleRigid.velocity.x, jumpVelocity);
       circleRigid.velocity = jump;
    }

    private bool IsGrounded()
    {
        //Set up ground check
        Collider2D groundCheck = Physics2D.OverlapCircle
            (feet.position, groundCheckSize, groundLayer);

        //check if player is grounded and reset jumps if so
        if (groundCheck)
        {
            currentJumps = extraJumps;
            return true;
        }
        return false;
    }
    //Respawn Player when killed
    internal void ResetToStart()
    {
        transform.position = startingPosition;
    }

}
