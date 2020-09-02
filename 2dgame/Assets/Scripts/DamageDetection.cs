using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour //the collider wrapped around the player to detect collisions
{

    public GameObject player;
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            player.GetComponent<PlayerMovement>().KnockbackCount = player.GetComponent<PlayerMovement>().KnockbackLength;  //register the amount of knockback here
            if(col.transform.position.x < transform.position.x)
            {
                player.GetComponent<PlayerMovement>().KnockFromRight = false;//got hit from right
            }
            else
            {
                player.GetComponent<PlayerMovement>().KnockFromRight = true;//got hit from left
            }
            SkeletonAI enemy = col.GetComponent<SkeletonAI>();
            KnightAI enemy2 = col.GetComponent<KnightAI>();
            FireballProperties enemy3 = col.GetComponent<FireballProperties>();
            if (enemy != null)
            {
                player.GetComponent<PlayerMovement>().TakeDamage(30);
            }
            else if (enemy2 != null)
            {
                player.GetComponent<PlayerMovement>().TakeDamage(15);
            }
            else if (enemy3 != null)
            {
                player.GetComponent<PlayerMovement>().TakeDamage(20);
            }
        }
        else if (col.gameObject.CompareTag("Ground"))
        {
            Debug.Log("This is the ground.Don't do anytthing");
        }
    }
    
}
