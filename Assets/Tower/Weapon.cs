using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int Power = 1;

    public int GetWeaponPower()
    {
        return Power;
    }
}
