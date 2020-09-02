using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProperties : MonoBehaviour
{
    public float Speed = 10f;
    public int Damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Got the player");
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }
}
