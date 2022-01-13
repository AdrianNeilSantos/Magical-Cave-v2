using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar; 
    private Collider colliderN;
    private bool isImmune;
    private float immuneDuration = 3f;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        colliderN = GetComponent<Collider>();
        isImmune = false;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Minus)){
            TakeDamage(1);
        }
        else if(Input.GetKeyDown(KeyCode.Equals)){
            RestoreHealth(1);
        }



        if(isImmune){
            if(immuneDuration > 0){
                immuneDuration -= Time.deltaTime;
            }
            else if (immuneDuration < 0){
                immuneDuration = 0;
            }
            else if(immuneDuration == 0){
                isImmune = false;
                immuneDuration = 3;
            }
        }


        if(currentHealth == 0){
            Die();
        }


    }



    public void TakeDamage(int damage){
        if(!isImmune){
            currentHealth -= damage;
            isImmune = true;
            updateHealth();
        }

    }

    public void RestoreHealth(int health){
        currentHealth += health;
        updateHealth();
    }

    public void updateHealth(){
        if(currentHealth < 0){
            currentHealth = 0;
        }
        else if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter(Collision other){
        // if(other.gameObject.tag == "Enemy"){
        //     TakeDamage(1);
        //     updateHealth();
        //     colliderN.isTrigger = true;
        //     Debug.Log(other.gameObject.name);
        // }
        Debug.Log(other);
    }

    public void Die(){
        FindObjectOfType<GameManager>().EndGame();
    }





}
