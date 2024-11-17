using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables de referencia privada
    private float horImput; //Referencia al input horizontal del teclado
    private float verImput; //Referencia al input vertical del teclado

    [Header("General References")]
    public Rigidbody playerRb; //Almacén del Rigidbody del Player. Me permite moverlo.
    public AudioSource playerAudio; //Referencia al reproductor de sonidos del player

    [Header("Movement Variables")]
    public float speed;
    public bool cakeNear= false;

    [Header("Jump Variables")]
    public float jumpForce;
    public bool isGrounded;

    [Header("Sound Library")]
    public AudioClip[] soundLibrary; //"Estantería" de sonidos del player

    [Header("Respawn Configuration")]
    public GameObject respawnPoint; //Ref al objeto que marca el punto de respawn (transform)
    public float fallLimit; //Valor en -y que al alcanzarlo se ejecutará el respawn

    public Animator animator;

    public GameObject Cake;
    public Rigidbody cakeRb; // Referencia al Rigidbody del Cake
    public float forceMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        transform.position = new Vector3(4.7f, 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Almacenar de manera constante el input de teclado en los ejes X e Y
        horImput = Input.GetAxis("Horizontal");
        verImput = Input.GetAxis("Vertical");
        Jump();

        if (horImput != 0 || verImput != 0)
        {
            Vector3 direction = new Vector3(horImput, 0, verImput).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        if (transform.position.y < fallLimit) { Respawn(); }

        animator.SetFloat("VelX", horImput);
        animator.SetFloat("VelY", verImput);

        if(animator.GetBool("isPushing") == true)
        {
            animator.Play("Pushing");
        }
        
        
        if(animator.GetBool("isPulling") == true)
        {
            animator.Play("Pull Heavy Object");
        }

        if ((animator.GetFloat("VelX") == 0) && (animator.GetFloat("VelY") == 0))
        {
            animator.SetBool("isPushing", false);
        }


        if (Input.GetMouseButtonDown(0) && (cakeNear == true))
        {
            animator.SetBool("isPulling", true);
            
        }
        // Mover el Cake mientras se mantenga el botón presionado y haya un objeto asignado
        if (cakeNear == true && Input.GetMouseButton(0))
        {
            // Calcula la fuerza a aplicar usando la velocidad del player
            Vector3 forceToApply = playerRb.velocity * forceMultiplier;

            // Aplica la fuerza al objeto Cake
            cakeRb.AddForce(forceToApply, ForceMode.Force);

            //cakeRb.AddForce(transform.forward * forceAmount, ForceMode.Force);
            animator.SetBool("isPulling", true);
        }

    }

    private void FixedUpdate()
    {
        //Aquí se codea/llama a acciones que dependan de la física CONSTANTE
        VelocityMove();
        //ForceMove();

        
    }
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Cake")) && (animator.GetFloat("VelX") != 0))
        {
            animator.SetBool("isPushing", true);
        }
        else if ((collision.gameObject.CompareTag("Cake")) && (animator.GetFloat("VelY") != 0))
        {
            animator.SetBool("isPushing", true);
        }


        if ((collision.gameObject.CompareTag("Cake")) && (Input.GetMouseButtonDown(0)) && (animator.GetFloat("VelX") != 0))
        {
            animator.SetBool("isPulling", true);
           
        }
        else if ((collision.gameObject.CompareTag("Cake"))&&(Input.GetMouseButtonDown(0)) && (animator.GetFloat("VelY") != 0))
        {
            animator.SetBool("isPulling", true);
        }
        else
        {
            animator.SetBool("isPulling", false) ;
        }

       
       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if ((collision.gameObject.CompareTag("Cake")) && (animator.GetFloat("VelX")!=0))
        {
            animator.SetBool("isPushing", true);
        }
        else if ((collision.gameObject.CompareTag("Cake")) && (animator.GetFloat("VelY") != 0))
        {
            animator.SetBool("isPushing", true);
        }

        if (collision.gameObject.CompareTag("Cake"))
        {
            cakeNear = true;
        }


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cake"))
        {
            animator.SetBool("isPushing", false);
            //a ver si va
            cakeNear = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            playerAudio.PlayOneShot(soundLibrary[2]);
        }
    }

    void VelocityMove()
    {
        //Movimiento basado en afectar al velocity: "Motor" que imita la capacidad de moverse de un ser vivo
        playerRb.velocity = new Vector3 (horImput * speed, playerRb.velocity.y, verImput * speed);
    }

    void ForceMove()
    {
        //Movimiento basado en aplicar fuerza de empuje en dos ejes: X/Z
        playerRb.AddForce(Vector3.right * horImput * speed);
        playerRb.AddForce(Vector3.forward * verImput * speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
           
            isGrounded = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.Play("Jump");
        }
    }

    

    void Respawn()
    {
        playerAudio.PlayOneShot(soundLibrary[1]);
        //Cambia la posición del player por la posición del punto de respawn
        transform.position = respawnPoint.transform.position;
    }
}
