using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int GoldReward = 25;
    [SerializeField] int GoldPenalty = 25;

    Bank bank;
    
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public bool RewardGold()
    {
        if (bank == null) return false;

        bank.Deposit(GoldReward);
        return true;
    }

    public bool StealGold()
    {
        if (bank == null) return false;

        bank.Withdrawl(GoldPenalty);
        return true;
    }

}
