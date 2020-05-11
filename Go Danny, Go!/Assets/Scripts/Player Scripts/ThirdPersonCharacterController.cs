using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;
    public GameObject explosion;

    /*
    public float jumpHeight;
    private Vector3 fallingVelocity;
    private float gravity;
    private CharacterController controller;
    */


    // Additions
    public float jumpHeight;
    private Rigidbody rbody;
    public LayerMask ground;
    public Transform feet;
    //public CapsuleCollider col;

    /*
    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

    }
    // EndOfAdd
    */

    // Update is called once per frame

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        jumpHeight = 3.0f;
        //gravity = 9.8f;
        //fallingVelocity = Vector3.zero;
    }

    void Update()
    {
        PlayerMovement();
    }

    /*
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
            col.bounds.center.z), col.radius * .9f, groundLayers);
        
    }
    */

    bool isGrounded()
    {
        if(Physics.CheckSphere(feet.position, 0.1f, ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if(Input.GetButtonDown("Jump") && (isGrounded()))
        {
            rbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
        }

        if(rbody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        /*
        // Additions
        fallingVelocity.y -= gravity * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            fallingVelocity.y -= Mathf.Sqrt(gravity * jumpHeight);
        }

        controller.Move(fallingVelocity * Time.deltaTime);
        // EndOfAdd
        */

        /*
        // Additions
        rb.AddForce(playerMovement * Speed);
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        // EndOfAdd
        */
    }
}
