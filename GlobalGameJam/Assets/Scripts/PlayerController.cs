using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public float speed = 5f;
    public float x, z;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Debug.Log(rb.velocity.x * x);
        //rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed);
        }
    }
}
