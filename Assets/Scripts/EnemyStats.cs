using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar; 

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "ProjectileWhite"){
            TakeDamage(1);
            updateHealth();
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

}
