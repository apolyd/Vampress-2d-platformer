using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonAI : MonoBehaviour
{
    public float Speed = 10f;   //skeleton base speed
    public float JumpSpeed = 30f;   //skeleton jump speed (not used)
    public bool FacingRight = true;   //what direction is the skeleton facing
    public int Health = 200;
    public float Xpatrol = 0;  // x and y coordinates to patrol areas if necessary (not used)
    public float Ypatrol = 0;
    public Text Status;
    public GameObject Player;
    private float move;
    private float FlashCount = 0; //to make the sprites flash
    private Animator SkeletonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        move = -1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(move == -1f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * move, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if(FacingRight)
            {
                Flip();
            }
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * move, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (!FacingRight)
            {
                Flip();
            }
        }

        if (FlashCount <= 0)
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

    
    public void Print()  //test print to detect the object
    {
        Debug.Log("Skeleton here.");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if(Health <= 0)
        {
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

    void Flip()  //rotate the sprite
    {
    FacingRight = !FacingRight;
    transform.Rotate(0f, 180f, 0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Bumper"))
        {
            move = -move;
        }
    }


}
