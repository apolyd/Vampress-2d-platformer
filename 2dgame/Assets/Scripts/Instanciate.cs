using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciate : MonoBehaviour
{
    public GameObject plat;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(plat, new Vector2(16,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
