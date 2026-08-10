using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero; //default no movement till input

    void Start()
    {
        //obtain rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //get inputs from keyboard (horizontal and vertical)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // checks what direction been inputed then changes move direction(one input at a time)
        if (h != 0 && v == 0) //if horizontal input move X axis
        {
            moveDirection = new Vector3(h, 0f, 0f);
        }
        else if (v != 0 && h == 0) //if vertical input move Z axis
        {
            moveDirection = new Vector3(0f, 0f, v);
        }


    }

    void FixedUpdate()
    {
        //constantly move in set direction
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
