using System;
using UnityEngine;

public class CoinTracker
{
    public static event Action AmtUpdated;

    private static CoinTracker s_instance;
    private CoinTracker() { Coin.CollectedByPlayer += CoinCollected; }
    ~CoinTracker() { Coin.CollectedByPlayer -= CoinCollected; }

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

    private void CoinCollected()
    {
        CoinAmt += GameConfig.CoinReward;
        AmtUpdated?.Invoke();
    }

}
