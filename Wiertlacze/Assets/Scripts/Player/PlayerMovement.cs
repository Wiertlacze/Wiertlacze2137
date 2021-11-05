using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sideForce = 500f;
    public Rigidbody rb;
    void Update()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);
        }
        
    }
}
