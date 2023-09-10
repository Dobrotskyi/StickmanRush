using UnityEngine;

public class GameBalance
{
    public const float MinShotDelay = 0.1f;
    private const float BasicShotDelay = 0.5f;
    private const float ShotDelayUpgrade = 0.05f;
    public const float EnemySpawnFrequency = 10f;
    public const float BulletTimeOfLifeInSec = 2f;
    private const int BasicDamage = 2;
    private const int DamageUpgrade = 5;
    public const int BossHP = 43;
    public const int RewardForBoss = 150;
    public const int EnemyHP = 10;
    public const int CoinReward = 50;

    private const int BasicPriceForUpgrade = 50;
    public static int CurrentDamageLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey("DamageLevel"))
                PlayerPrefs.SetInt("DamageLevel", 1);
            return PlayerPrefs.GetInt("DamageLevel");
        }
    }

    public static int Damage => BasicDamage + DamageUpgrade * (CurrentDamageLevel - 1);

    public static int PriceForDamageUpgrade => BasicPriceForUpgrade * CurrentDamageLevel;

    public static bool TryUpgradeDamage()
    {
        if (CoinTracker.Instance.CoinAmt >= PriceForDamageUpgrade)
        {
            CoinTracker.Instance.Withdraw(PriceForDamageUpgrade);
            PlayerPrefs.SetInt("DamageLevel", CurrentDamageLevel + 1);
            return true;
        }
        return false;
    }

    public static int CurrentFireRateLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey("FireRateLevel"))
                PlayerPrefs.SetInt("FireRateLevel", 1);
            return PlayerPrefs.GetInt("FireRateLevel");
        }
    }

    public static float FireRate => BasicShotDelay - ShotDelayUpgrade * (CurrentFireRateLevel - 1);
    public static int PriceForFireRateUpgrade => BasicPriceForUpgrade * CurrentFireRateLevel;

    public static bool TryUpgradeFireRate()
    {
        if (CoinTracker.Instance.CoinAmt >= PriceForFireRateUpgrade)
        {
            if (FireRateReachedMax())
                return false;

            CoinTracker.Instance.Withdraw(PriceForFireRateUpgrade);
            PlayerPrefs.SetInt("FireRateLevel", CurrentFireRateLevel + 1);
            return true;
        }
        return false;
    }

    public static bool FireRateReachedMax() => MinShotDelay > BasicShotDelay - ShotDelayUpgrade * CurrentFireRateLevel;
}
