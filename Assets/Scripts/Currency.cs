using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Currency
{
    public static int currency = 0;


    public static void addCurrency(int num){
        currency += num;
    }

    public static int getCurrency(){
        return currency;
    }

}
