using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemywalk : EnemyController
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (isFacingRight == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
        else if (collider.tag == "Enemy")
        {
            Flip();
        }
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
}
