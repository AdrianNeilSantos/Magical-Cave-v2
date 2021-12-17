using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runspeed;
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
    [SerializeField] private float detectDistance;
    [SerializeField] private string colorTrigger;


    //REFERENCES
    private CharacterController controller;
    public Transform playerTransform;
    public GameObject colorTag;
    private Animator animator;
    


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

    }


    void Update()
    {
        float EnemyToPlayerDistance = Vector3.Distance(playerTransform.position, transform.position);

        if(EnemyToPlayerDistance < detectDistance){
            Move();
        }
        else{
            Idle();
        }

        applyGravity();
    }


    private void Move(){
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        //stops applying gravity when grounded
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float horizontal = 1f;
        float vertical = 0f;

        //setting up the direction towards the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;



        if(direction.magnitude >= 0.1f && (colorTag.name == "White" || colorTag.name == colorTrigger)){
            //no mainCam variable
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            if(isGrounded){
                if(direction != Vector3.zero){
                    Walk();
                }
            }

            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
        else{
            Idle();
        }



        
    }

    private void applyGravity(){
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    private void Idle(){
        moveSpeed = 0f;
        animator.SetFloat("AnimIndex",0f,0.5f,Time.deltaTime);
    }

    private void Walk(){
        moveSpeed = walkSpeed;
        animator.SetFloat("AnimIndex",0.3333f,0.5f,Time.deltaTime);
    }


    private void Run(){
        moveSpeed = runspeed;
        animator.SetFloat("AnimIndex",0.666667f,0.5f,Time.deltaTime);
    }

    private void Die(){
        moveSpeed = 0;
        animator.SetFloat("AnimIndex",1f,0.5f,Time.deltaTime);

    }


}
