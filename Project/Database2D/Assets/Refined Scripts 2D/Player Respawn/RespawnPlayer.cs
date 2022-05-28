using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    /*Access transform of Player and RespawnPoint
    Use this if you want to choose a respawnpoint rather than attaching to player script
    and respawning at the start*/
    [SerializeField] Transform player;
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Set player to Respawn Point
        player.transform.position = respawnPoint.transform.position;
    }
}
