using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBumperCollision : MonoBehaviour  // a simple collision to detect if the player falls into a pit
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerMovement>().TakeDamage(1000); //just kill the player with a huge amount of damage
        }
    }
}
