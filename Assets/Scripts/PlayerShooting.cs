using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    private bool leftHand;

    private Vector3 destination;
    private float timeToFire;
    private float fireRate = 4;
    private float arcRange = 1;




    //REFERENCES

    public Camera cam;
    public GameObject projectileWhite;
    public GameObject projectileBlue;
    public GameObject projectileRed;
    public GameObject isBlueFired;
    public Transform LHFirepoint, RHFirepoint;
    public GameObject ColorTag;
    public float projectileSpeedWhite = 20;
    public float projectileSpeedBlue = 5;
    public float projectileSpeedRed = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= timeToFire && ColorTag.name != "None"){
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
        if(ColorTag.name == "White"){
            InstantiateProjectileWhite(firePoint);
        }
        else if(ColorTag.name =="Blue"){
            if(isBlueFired.name == "False"){
                InstantiateProjectileBlue(firePoint);
                isBlueFired.name = "True";
            }
            
        }        
        else if(ColorTag.name =="Red"){
            InstantiateProjectileRed(firePoint);
        }
    }


    void InstantiateProjectileWhite(Transform firePoint){
            var projectileObj = Instantiate (projectileWhite, firePoint.position, Quaternion.identity) as GameObject;
            //code for positioning projectile direction : forward of firepoints
            projectileObj.GetComponent<Rigidbody>().velocity = firePoint.forward * projectileSpeedWhite;

            iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange),Random.Range(-arcRange, arcRange),0), Random.Range(0.5f,2));
    }


    void InstantiateProjectileBlue(Transform firePoint){
            var projectileObj = Instantiate (projectileBlue, firePoint.position, Quaternion.identity) as GameObject;
            //code for positioning projectile direction : forward of firepoints
            projectileObj.GetComponent<Rigidbody>().velocity = firePoint.forward * projectileSpeedBlue;

            iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange),Random.Range(-arcRange, arcRange),0), Random.Range(0.5f,2));
    }


       void InstantiateProjectileRed(Transform firePoint){
            var projectileObj = Instantiate (projectileRed, firePoint.position, Quaternion.identity) as GameObject;
            //code for positioning projectile direction : forward of firepoints
            projectileObj.GetComponent<Rigidbody>().velocity = firePoint.forward * projectileSpeedRed;

            iTween.PunchPosition(projectileObj, new Vector3(Random.Range(-arcRange, arcRange),Random.Range(-arcRange, arcRange),0), Random.Range(0.5f,2));
    }





}
