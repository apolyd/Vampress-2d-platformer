using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public static bool isTouched; //true player touches the ground can jump.False player doesn't touch the ground can't jump
    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Entered");
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouched = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Exit");
        if (col.gameObject.CompareTag("Ground"))
        {
            isTouched = false;
        }
    }
}
