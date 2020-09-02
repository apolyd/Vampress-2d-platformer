using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionTrigger : MonoBehaviour
{
    [SerializeField] private int HealthBuff = 20;
    public AudioSource sound;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.GetComponent<PlayerMovement>().Health < 100)
            {
                col.gameObject.GetComponent<PlayerMovement>().Health = col.gameObject.GetComponent<PlayerMovement>().Health + HealthBuff;
                if (col.gameObject.GetComponent<PlayerMovement>().Health > 100)
                {
                    col.gameObject.GetComponent<PlayerMovement>().Health = 100;
                }
                col.gameObject.GetComponent<PlayerMovement>().PlayerHealth.fillAmount = col.gameObject.GetComponent<PlayerMovement>().Health / 100f;
                sound.Play();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                transform.position = Vector3.one * 99999f; //move the object somewhere out of the camera for a bit until it finishes its sound
                Destroy(gameObject, 0.5f);// wait 0.5 seconds (delay) for the sound to play
            }
        }
    }

}
