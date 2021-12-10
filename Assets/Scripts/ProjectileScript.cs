using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject projectileImpact;
    private bool collided;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Projectile" && other.gameObject.tag != "Player" && !collided){
            collided = true;


            if(other.gameObject.tag != "Bounds"){
                //Quaternion.Identity = rotation of prefab
                var impact = Instantiate(projectileImpact, other.contacts[0].point, Quaternion.identity) as GameObject;

                
                Destroy (impact,1);
            }

            Destroy (gameObject);
        }
    }


}
