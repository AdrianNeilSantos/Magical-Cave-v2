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
    private bool isFeared;
    private float fearDuration;
    private bool isDead = false;



    private Vector3 forward, right;
    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float detectDistance;
    [SerializeField] private float damageDistance = 2;
    [SerializeField] private string colorTrigger;


    //REFERENCES
    private CharacterController controller;
    public Transform playerTransform;
    public GameObject colorTag;
    private Animator animator;
    private EnemyStats enemyStats;
    private PlayerStats playerStats;
    private Collider colliderN;
    public GameObject player;
    


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        isFeared = false;
        enemyStats = GetComponent<EnemyStats>();
        playerStats = player.GetComponent<PlayerStats>();
        colliderN = GetComponent<Collider>();

    }


    void Update()
    {
        float EnemyToPlayerDistance = Vector3.Distance(playerTransform.position, transform.position);

        if( (isFeared || EnemyToPlayerDistance < detectDistance) && !isDead){
            Move();
        }
        else if(isDead){
            Die();
            Destroy(this.gameObject, 3);
        }
        else{
            Idle();
        }

        applyGravity();
        if(fearDuration > 0){
            fearDuration -= Time.deltaTime;
        }
        else if (fearDuration < 0){
            fearDuration = 0;
            isFeared = false;
        }


        if(EnemyToPlayerDistance < damageDistance && !isDead){
            playerStats.TakeDamage(1);
        }

        if(enemyStats.currentHealth <= 0){
            Die();
        }
    }


    private void Move(){
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        //stops applying gravity when grounded
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        // float horizontal = 1f;
        // float vertical = 0f;
        Vector3 direction;
        //setting up the direction towards the player
        if(isFeared){
            //away from player
            direction = (playerTransform.position - transform.position).normalized *-1;
        }
        else{
            //towards player
            direction = (playerTransform.position - transform.position).normalized;
        }



        if( (direction.magnitude >= 0.1f && (colorTag.name == "White" || colorTag.name == colorTrigger)) || isFeared ){
            //no mainCam variable
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            if(isGrounded){
                if(direction != Vector3.zero){
                    Run();
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


    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ProjectileRed"){
            fearDuration = 5;
            isFeared = true;
        }
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
        colliderN.isTrigger = true;
        isDead = true;
    }


}
