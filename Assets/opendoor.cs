using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;

    public LayerMask WhatIsPlayer;
    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, WhatIsPlayer); 

        if(playerDetected == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width, height, 1));
    }
}
