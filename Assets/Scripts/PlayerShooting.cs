using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Camera cam;
    public GameObject projectile;
    public Transform LHFirepoint, RHFirepoint;
    private bool leftHand;
    private Vector3 destination;
    private float timeToFire;
    private float fireRate = 4;
    private float arcRange = 1;

    public float projectileSpeed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeToFire ){
            timeToFire = Time.time + 1/fireRate;
            ShootProjectile();
        }
    }


    void ShootProjectile(){
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            destination = hit.point;
        }
        else{
            //adjustable value for "1000"
            destination = ray.GetPoint(1000);
        }

        if(leftHand){
            leftHand = false;
            InstantiateProjectile(LHFirepoint);
        }
        else{
            leftHand = true;
            InstantiateProjectile(RHFirepoint);
        }



    }

    void InstantiateProjectile(Transform firePoint){
            var projectileObj = Instantiate (projectile, firePoint.position, Quaternion.identity) as GameObject;
            //code for positioning projectile direction : forward of firepoints
            projectileObj.GetComponent<Rigidbody>().velocity = firePoint.forward * projectileSpeed;

            iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange),Random.Range(-arcRange, arcRange),0), Random.Range(0.5f,2));
    }


}
