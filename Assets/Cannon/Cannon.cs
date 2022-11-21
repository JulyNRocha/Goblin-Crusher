using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float waitDelay = 1f;

    void Start()
    {
        StartCoroutine(Build());
    }
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

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitDelay);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }
}
