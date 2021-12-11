using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{

    public GameObject colorTag;

    public GameObject lampLightObject;
    public GameObject spotLightObject;

    Light lampLight;
    Light spotLight;


    enum LightColor{White, Red, Blue, None};


    private LightColor currentLightColor;

    void Start() {
        currentLightColor = LightColor.None;
        lampLight = lampLightObject.GetComponent<Light>();
        spotLight = spotLightObject.GetComponent<Light>();    
        updateLights();
        updateColorTag();
    }

    // Update is called once per frame
    void Update()
    {
        defineLightColor();
    }


    void defineLightColor(){

        LightColor prevLightColor = currentLightColor;

        if(Input.GetKeyDown(KeyCode.Q)){
            currentLightColor =  LightColor.White;
        }
        else if(Input.GetKeyDown(KeyCode.E)){
            currentLightColor = LightColor.Blue;
        }
        else if(Input.GetKeyDown(KeyCode.R)){
            currentLightColor = LightColor.Red;
        }
        
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R)){
            if(prevLightColor == currentLightColor){
                currentLightColor = LightColor.None;
            }
                updateLights();
                updateColorTag();
        }



        prevLightColor = currentLightColor;

    }


    void updateLights(){
        if(currentLightColor == LightColor.White){
            spotLight.color = Color.white;
            lampLight.color = Color.white;

        }
        else if(currentLightColor == LightColor.Blue){
            spotLight.color = Color.blue;
            lampLight.color = Color.blue;

        }
        else if(currentLightColor == LightColor.Red){
            spotLight.color = Color.red;
            lampLight.color = Color.red;

        }
        else if(currentLightColor == LightColor.None){
            spotLight.color = Color.black;
            lampLight.color = Color.black;

        }


    }


    void updateColorTag(){
        if(currentLightColor == LightColor.None){
            colorTag.name = "None";
        }
        else if(currentLightColor == LightColor.White){
            colorTag.name = "White";

        }        
        else if(currentLightColor == LightColor.Blue){
            colorTag.name = "Blue";

        }        
        else if(currentLightColor == LightColor.Red){
            colorTag.name = "Red";
        }

    }

}
