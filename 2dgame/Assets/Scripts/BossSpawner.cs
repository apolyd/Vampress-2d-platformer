using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss;

    void Start() // disable the boss at the beginning
    {
        Boss.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)  //when the player enters the pit enable the boss and destroy this collider so that it is not triggered again
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Boss.SetActive(true);
            Destroy(gameObject);
        }
    }
}
