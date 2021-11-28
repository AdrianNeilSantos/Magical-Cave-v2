using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour, IInventoryItem
{
    public string Name{

        get{
            return "Mushroom";
        }

    }

    public Sprite _Image;

    public Sprite Image{
        get{
            return _Image;
        }
    }

    public void OnPickup(){
        gameObject.SetActive(false);
    }
}
