using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOnColor : MonoBehaviour
{


    public GameObject whiteObject;
    public GameObject blueObject;
    public GameObject redObject;
    public GameObject colorTag;

    public Color redFog;
    public Color blueFog;
    public Color noneFog;

    void Update()
    {
        if(colorTag.name == "White"){
            showWhite();
        }
        else if(colorTag.name == "Blue"){
            showBlue();
        }
        else if(colorTag.name == "Red"){
            showRed();
        }
        else{
            showNone();
        }

    }



    void showWhite(){
        RenderSettings.fog = false;
        whiteObject.SetActive(true);
        blueObject.SetActive(true);
        redObject.SetActive(true);
    }
    void showBlue(){
        RenderSettings.fog = true;
        RenderSettings.fogColor = blueFog;
        whiteObject.SetActive(false);
        blueObject.SetActive(true);
        redObject.SetActive(false);
    }
    void showRed(){
        RenderSettings.fog = true;
        RenderSettings.fogColor = redFog;
        whiteObject.SetActive(false);
        blueObject.SetActive(false);
        redObject.SetActive(true);
    }

    void showNone(){
        RenderSettings.fog = true;
        RenderSettings.fogColor = noneFog;
        whiteObject.SetActive(false);
        blueObject.SetActive(false);
        redObject.SetActive(false);
    }

}
