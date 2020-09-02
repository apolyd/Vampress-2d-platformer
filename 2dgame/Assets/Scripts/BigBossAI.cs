using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BigBossAI : MonoBehaviour
{
    public int Health = 250;
    private float FlashCount = 0; //to make the sprites flash
    public GameObject EndTitle;
    public Text WinTitle, LoseTitle, AlternatePlay;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //nothing to add here
    }

    // Update is called once per frame
    void Update()
    {
        if (FlashCount <= 0)  //when there is no flashing make sure the sprite is enabled
        {
            if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled; //turn it on and off
            FlashCount -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)   //take damage is called from a collision trigger
    {
        Health -= damage;

        if (Health <= 0)
        {
            EndTitle.SetActive(true);
            WinTitle.enabled = true;
            LoseTitle.enabled = false;
            AlternatePlay.text = "Replay";
            player.GetComponent<PlayerMovement>().DisableControl = 1;
            Die();
        }
    }

    public void SetFlash(float a)
    {
        FlashCount = a;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
