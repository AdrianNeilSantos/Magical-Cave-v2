using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueProjectile : MonoBehaviour
{

    private GameObject player;
    private GameObject isBlueFired;
    private GameObject colorTag;
    
    public GameObject projectileImpact;
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        isBlueFired = GameObject.Find("/Player/isBlueFired/True");

        colorTag = GameObject.Find("/Player/Blue");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && colorTag.name == "Blue"){
            player.transform.position = this.transform.position;
            isBlueFired.name = "False";
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Projectile" && other.gameObject.tag != "Player" && !collided){
            collided = true;


            if(other.gameObject.tag != "Bounds"){
                //Quaternion.Identity = rotation of prefab
                var impact = Instantiate(projectileImpact, other.contacts[0].point, Quaternion.identity) as GameObject;

                Destroy (impact,1);
            }
            isBlueFired.name = "False";
            Destroy (gameObject);
            
        }
    }
    
}
