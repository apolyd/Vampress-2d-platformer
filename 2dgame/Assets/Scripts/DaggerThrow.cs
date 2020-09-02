using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DaggerThrow : MonoBehaviour
{
    public Transform DaggerTriggerPoint;
    public GameObject DaggerProjectile;
    public Text DaggerAmmo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && this.gameObject.GetComponent<PlayerMovement>().NumberOfDaggers!=0) //make sure the player has daggers left
        {
            ShootDagger();
            gameObject.GetComponent<PlayerMovement>().NumberOfDaggers--;
            DaggerAmmo.text = gameObject.GetComponent<PlayerMovement>().NumberOfDaggers.ToString();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    void ShootDagger()
    {
        Instantiate(DaggerProjectile, DaggerTriggerPoint.position, DaggerTriggerPoint.rotation);
    }
}
