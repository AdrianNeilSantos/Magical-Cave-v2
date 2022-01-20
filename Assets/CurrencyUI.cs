using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    TextMeshProUGUI score;


    void Start(){
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        score.text = Currency.getCurrency().ToString();
    }



}
