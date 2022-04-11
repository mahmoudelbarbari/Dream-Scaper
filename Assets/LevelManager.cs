using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void RespawnPlayer()
    {
        FindObjectOfType<CharacterController2D>().transform.position = CurrentCheckpoint.transform.position;
    }

    public void SpawnEnemy()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
