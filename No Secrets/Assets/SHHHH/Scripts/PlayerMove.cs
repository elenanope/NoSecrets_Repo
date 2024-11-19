using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runningSpeed;
    

    public Animator animator;

    private float x, z;
    public Rigidbody rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public bool isGrounded;
  

    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Horizontal");
        x = Input.GetAxis("Vertical");


        animator.SetFloat("VelZ", z);
        animator.SetFloat("VelX", x);





        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            
            animator.Play("Punching");

            //no va
        }


        if (x > 0 || x < 0 || z > 0 ||z < 0)
        {
            animator.SetBool("Other", true);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKey("space") && isGrounded)
        {
            animator.Play("Jump");

            rb.AddForce(Vector3.up*jumpHeight,ForceMode.Impulse);   
        }

    }
    private void FixedUpdate()
    {
        //Aquí se codea/llama a acciones que dependan de la física CONSTANTE
        VelocityMove();
        //ForceMove();
    }


    void VelocityMove()
    {
        //Movimiento basado en afectar al velocity: "Motor" que imita la capacidad de moverse de un ser vivo
        rb.velocity = new Vector3(x * runningSpeed, rb.velocity.y, z * runningSpeed);
    }



}
