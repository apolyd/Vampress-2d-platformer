using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;   //player base speed
    public float JumpSpeed = 350f;   //player jump speed
    public bool FacingRight = true;   //what direction is the player facing
    public LayerMask PlatformLayer;   //ground check
    public int NumberOfDaggers = 30;
    public int Health = 100;
    public Image PlayerHealth;
    public Text DaggerAmmo;
    public float Knockback = 10f;
    public float KnockbackLength = 0.2f;
    public float KnockbackCount = 0;
    public bool KnockFromRight;
    public GameObject EndTitle;
    public Text WinTitle, LoseTitle, AlternatePlay;
    public int DisableControl = 0;

    private Animator FumikoAnimator;   //the animator of the object
    private Transform CheckPos;
    [SerializeField] private GameObject projectile;
   // [SerializeField] float SpeedBoost = 10f;
   // [SerializeField] float JumpBoost = 10f;
    // private bool isTouched;

    void Start()
    {
        FumikoAnimator = this.GetComponent<Animator>();
        //CheckPos = this.GetComponent<Transform>();
        CheckPos = transform.Find("GCheck");
        DaggerAmmo.text = NumberOfDaggers.ToString();
        EndTitle.SetActive(false);
        DisableControl = 0;
    }

  //  void Update()
  //  {
  //      
  //  }

    void Update()
    {
        //DaggerAmmo.text = NumberOfDaggers.ToString();
        float move = Input.GetAxis("Horizontal"); //get the direction from player (-1 left / 1 right)
        if(DisableControl == 1)
        {
            move = 0;
        }
     //   Debug.Log(isTouched.ToString());
        if (move > 0 && !FacingRight)
            Flip();
        else if (move < 0 && FacingRight)
            Flip();
    
        FumikoAnimator.SetFloat("Speed", Mathf.Abs(move));
        if(KnockbackCount <= 0) //new code here ****************************************************
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true; //just make sure the sprite is always enabled after blinking
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * move , this.gameObject.GetComponent <Rigidbody2D>().velocity.y);
        }
        else
        {
            if (KnockFromRight)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-Knockback, Knockback);
                if(this.gameObject.GetComponent<SpriteRenderer>().enabled == true) //start blinking to indicate dmg
                {
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
               
            }
            if (!KnockFromRight)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Knockback, Knockback);
                if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)  //start blinking to indicate dmg from the left now
                {
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            KnockbackCount -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1")) && GroundCheck.isTouched == true)
        {
            Debug.Log(GroundCheck.isTouched);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpSpeed , ForceMode2D.Impulse);
        }

    

    }

    void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

   


    public void TakeDamage(int damage) //take damage
    {
        Health -= damage;
        PlayerHealth.fillAmount -= damage/100f ;

        if (Health <= 0) //setup the menu when the player died
        {
            EndTitle.SetActive(true);
            WinTitle.enabled = false;
            LoseTitle.enabled = true;
            AlternatePlay.text = "Play again";

            Die();
        }
    }

    public void Heal(int HealAmount) //Heal is called when a collision with potion is detected
    {
        Health += HealAmount;
        if(Health <= 100)
        {
            PlayerHealth.fillAmount += HealAmount / 100f;
        }
        else
        {
            Health = 100;
            PlayerHealth.fillAmount = 1f;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
