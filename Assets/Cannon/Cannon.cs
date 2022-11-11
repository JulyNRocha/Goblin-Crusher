using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public bool CreateCannon(Cannon cannon, Vector3 position)
    {
        Instantiate(cannon, position, Quaternion.identity);
        return true;
    }
}
