using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinCollect : MonoBehaviour
{
    public static CoinCollect instance;

    public int currentCoin;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Addcoin(0);
    }

    public void Addcoin(int coinAmount)
    {
        currentCoin += coinAmount;
        
    }
}
