using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectible : MonoBehaviour, IInventoryItem
{
    public string Name{

        get{
            return "Axe";
        }

    }

    public Sprite _Image = null;

    public Sprite Image{
        get{
            return _Image;
        }
    }

    public void OnPickup(){
        gameObject.SetActive(false);
    }


}
