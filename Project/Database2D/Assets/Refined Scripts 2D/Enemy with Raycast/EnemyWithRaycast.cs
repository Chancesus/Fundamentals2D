using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithRaycast : MonoBehaviour
{
    //Hold left and right sensors
    [SerializeField] Transform leftSensor;
    [SerializeField] Transform rightSensor;

    //Initialize Rigidbody and Direction
    Rigidbody2D enemyRigid;
     float _direction = -1;

    void Start()
    {
        //Get rigidbody component from unity
       enemyRigid = GetComponent<Rigidbody2D>();
    }

    
   void Update()
    {
        //Set movement
      enemyRigid.velocity = new Vector2(_direction, enemyRigid.velocity.y);
        //Switch between left and right sensor
        if (_direction < 0)
        {
            ScanSensor(leftSensor);
        }
        else
        {
            ScanSensor(rightSensor);
        }
        
    }

    private void ScanSensor(Transform sensor)
    {
        //Draw downward ray and check collider
        Debug.DrawRay(sensor.position, Vector2.down * 0.3f, Color.yellow);
        RaycastHit2D hit = Physics2D.Raycast(sensor.position, Vector2.down, 0.5f);
        if (hit.collider == null)
            TurnAround();
        
        //Draw horizontal ray and check collider
        Debug.DrawRay(sensor.position, new Vector2(_direction, 0) * 0.3f, Color.yellow);
        RaycastHit2D sidehit = Physics2D.Raycast(sensor.position, new Vector2(_direction, 0), 0.3f);
        if (sidehit.collider != null)
            TurnAround();
    }

    void TurnAround()
    {
        //Flip direction and Sprite
        _direction *= -1;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = _direction > 0;
    }

    //Reset the player to start if collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
       var player = collision.collider.GetComponent<CircleMover>();
        if (player != null)
        {
            player.ResetToStart();
        }
    }
}
