using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
 
 private void OnTriggerEnter(Collider other) {
     if(other.name == "Player"){
         Currency.addCurrency(1);
         Debug.Log(Currency.getCurrency());
         Destroy(gameObject);
     }
 }
}
