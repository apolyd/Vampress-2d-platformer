using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
     //   Destroy(this.gameObject);
        Debug.Log("Entered Dagger Collision");
        if (col.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit Ground");
        }
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
        }
    }

}
