using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Debug.Debug.Log(" Hello Julius ");
    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    private Vector3 forward, right;
    private Vector3 moveDirection;
    private Vector3 velocity;


    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;


    //REFERENCES

    private CharacterController controller;
    private Animator animator;
    public Transform cam;


    private void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update() {
        Move();
    }


    private void Move(){


        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        //stops applying gravity when grounded
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }



        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            if(isGrounded){
                if(direction != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
                    //Walk
                    Walk();
                }
                else if(direction != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
                    //Run
                    Run();
                }
             }
             


            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);



        }

        else{



            Idle();
        }

        if( isGrounded && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

            //gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

    }










    private void Idle(){
        animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }



    private void Walk(){
        moveSpeed = walkSpeed;
        animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }


    private void Run(){
        moveSpeed = runSpeed;
        animator.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        
    }


    private void Jump(){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        animator.SetTrigger("Jump");
    }

}
