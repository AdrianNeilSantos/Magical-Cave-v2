using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBound : MonoBehaviour
{
    private EnemyStats enemyStats;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            FindObjectOfType<GameManager>().EndGame();
        }
        else if(other.tag == "Enemy"){
            enemyStats = other.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(1000);
        }
    }



}
