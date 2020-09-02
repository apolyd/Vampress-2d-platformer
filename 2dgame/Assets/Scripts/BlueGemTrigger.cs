using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemTrigger : MonoBehaviour
{
    [SerializeField]private float JumpBuff = 1f;
    public AudioSource sound;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            col.gameObject.GetComponent<PlayerMovement>().JumpSpeed = col.gameObject.GetComponent<PlayerMovement>().JumpSpeed + JumpBuff;
            if (col.gameObject.GetComponent<PlayerMovement>().JumpSpeed >= 20f)    //Just cap speed in case something ridiculous is going to happen with speed buffs
            {
                col.gameObject.GetComponent<PlayerMovement>().JumpSpeed = 20f;
            }
            sound.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.position = Vector3.one * 99f;
            Destroy(gameObject, 0.5f);// wait 0.5 seconds (delay) for the sound to play
        }
    }
}
