using EnemyMechanics;
using System;
using UnityEngine;

public class CoinTracker
{
    public static event Action AmtUpdated;

    private static CoinTracker s_instance;
    private CoinTracker()
    {
        Coin.CollectedByPlayer += CoinCollected;
        Boss.BossIsDead += RewardForBoss;
    }
    ~CoinTracker()
    {
        Coin.CollectedByPlayer -= CoinCollected;
        Boss.BossIsDead -= RewardForBoss;
    }

    public static CoinTracker Instance
    {
        get
        {
            if (s_instance == null)
                s_instance = new CoinTracker();

            return s_instance;
        }
    }

    public int CoinAmt
    {
        get
        {
            if (!PlayerPrefs.HasKey("CoinsAmt"))
                PlayerPrefs.SetInt("CoinsAmt", 0);
            return PlayerPrefs.GetInt("CoinsAmt");
        }
        private set
        {
            if (!PlayerPrefs.HasKey("CoinsAmt"))
                PlayerPrefs.SetInt("CoinsAmt", 0);
            else
                PlayerPrefs.SetInt("CoinsAmt", value);
        }
    }

    public void Withdraw(int amt)
    {
        if (CoinAmt >= amt)
        {
            CoinAmt -= amt;
            AmtUpdated?.Invoke();
        }
    }

    private void CoinCollected()
    {
        CoinAmt += GameBalance.CoinReward;
        AmtUpdated?.Invoke();
    }

    private void RewardForBoss()
    {
        CoinAmt += GameBalance.RewardForBoss;
        AmtUpdated?.Invoke();
    }

}
