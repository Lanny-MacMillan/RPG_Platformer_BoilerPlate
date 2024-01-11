using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Player player;

    public int currency;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    public bool HaveEnoughCurrency(int _price)
    {

        if(_price > currency)
        {
            Debug.Log("Not neough currency");
            return false;
        }


        currency = currency - _price;
        return true;
    }

    public int GetCurrency() => currency;
}
