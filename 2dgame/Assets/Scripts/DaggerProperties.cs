using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerProperties : MonoBehaviour
{
    public float Speed = 20f;
    public int Damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //if the object is classified as enemy
        {
            Destroy(gameObject);
            SkeletonAI enemy = col.GetComponent<SkeletonAI>();
            KnightAI enemy2 = col.GetComponent<KnightAI>();
            BigBossAI enemy3 = col.GetComponent<BigBossAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
                enemy.SetFlash(0.2f);
            }else if(enemy2 != null)
            {
                enemy2.TakeDamage(Damage);
                enemy2.SetFlash(0.2f);
            }else if(enemy3 != null)
            {
                Debug.Log("sdffsafsdfsdfsdfsdfsdfds");
                enemy3.TakeDamage(Damage);
                enemy3.SetFlash(0.2f);
            }
        }else if (col.gameObject.CompareTag("Ground")) // just destroy the projectile if it hits the ground
        {
            Destroy(gameObject);
        }
        
    }
}
