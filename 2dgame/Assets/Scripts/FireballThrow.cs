using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballThrow : MonoBehaviour
{
    public Transform FireballTriggerPoint;
    public GameObject FireballProjectile;
    public float Cooldown = 1f;
    public float CooldownRate;

    void Start()
    {
        CooldownRate = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        CooldownRate -= Time.deltaTime;
        if(CooldownRate <= 0)
        {
            ShootFireball();
            CooldownRate = Cooldown;
        }
    }

    void ShootFireball()
    {
        Instantiate(FireballProjectile, FireballTriggerPoint.position, FireballTriggerPoint.rotation);
    }
}
