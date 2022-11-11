using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateCannon(Cannon cannon, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(cannon, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        
        return false;
    }
}
