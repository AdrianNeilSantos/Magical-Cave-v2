using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar; 
    private Collider colliderN;
    private float immuneDuration = 3f;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        colliderN = GetComponent<Collider>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Minus)){
            TakeDamage(1);
            updateHealth();
        }
        else if(Input.GetKeyDown(KeyCode.Equals)){
            RestoreHealth(1);
            updateHealth();
        }


        if(immuneDuration > 0){
            immuneDuration -= Time.deltaTime;
        }
        else if (immuneDuration < 0){
            immuneDuration = 0;
            colliderN.isTrigger = false;
        }



    }



    void TakeDamage(int damage){
        currentHealth -= damage;
    }

    void RestoreHealth(int health){
        currentHealth += health;
    }

    void updateHealth(){
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


}
