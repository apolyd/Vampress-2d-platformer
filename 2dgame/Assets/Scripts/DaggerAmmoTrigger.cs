using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DaggerAmmoTrigger : MonoBehaviour
{
    public Text DaggerAmmo;
    [SerializeField]private int DaggerAmmoPickup = 10; //how much ammo the powerup provides
    public AudioSource sound;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerMovement>().NumberOfDaggers = col.gameObject.GetComponent<PlayerMovement>().NumberOfDaggers + DaggerAmmoPickup;
            col.gameObject.GetComponent<PlayerMovement>().DaggerAmmo.text = col.GetComponent<PlayerMovement>().NumberOfDaggers.ToString();
            sound.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            transform.position = Vector3.one * 99f; //move the object somewhere out of the camera for a bit until it finishes its sound
            Destroy(gameObject, 0.5f);// wait 0.5 seconds (delay) for the sound to play 
        }   
    }

}
