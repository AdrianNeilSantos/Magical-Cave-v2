using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Movement : MonoBehaviour
{

    private Animator animator;
    [SerializeField] public float animationMode;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();




    }

    

    void Update() {

        if(animationMode == 0f){
            Idle1();
        }
        else if(animationMode == 0.5f){
            Idle2();
        }
        else if(animationMode == 1f){
            Twerk();
        }
        else{
            Idle1();
        }


        
    }


    private void Idle1(){
        animator.SetFloat("Animation",0f,0.01f,Time.deltaTime);
    }

    private void Idle2(){
        animator.SetFloat("Animation",0.5f,0.01f,Time.deltaTime);
    }



    private void Twerk(){
        animator.SetFloat("Animation",1f,0.01f,Time.deltaTime);
    }



}
