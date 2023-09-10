using UnityEngine;

public class GameBalance
{
    public const float BulletTimeOfLifeInSec = 2f;

    private const int DamageUpgrade = 5;
    private const float ShotDelayUpgrade = 0.05f;
    private const float MinShotDelay = 0.1f;
    private const int BasicPriceForUpgrade = 50;

    public static float EnemySpawnFrequency
    {
        get
        {
            if (!PlayerPrefs.HasKey("EnemySpawnFrequency"))
                PlayerPrefs.SetFloat("EnemySpawnFrequency", 10);
            return PlayerPrefs.GetFloat("EnemySpawnFrequency");
        }

        set => PlayerPrefs.SetFloat("EnemySpawnFrequency", value);

    }

    public static int BossHP
    {
        get
        {
            if (!PlayerPrefs.HasKey("BossHP"))
                PlayerPrefs.SetInt("BossHP", 43);
            return PlayerPrefs.GetInt("BossHP");
        }

        set => PlayerPrefs.SetInt("BossHP", value);

    }

    public static int RewardForBoss
    {
        get
        {
            if (!PlayerPrefs.HasKey("RewardForBoss"))
                PlayerPrefs.SetInt("RewardForBoss", 150);
            return PlayerPrefs.GetInt("RewardForBoss");
        }

        set => PlayerPrefs.SetInt("RewardForBoss", value);

    }

    public static int EnemyHP
    {
        get
        {
            if (!PlayerPrefs.HasKey("EnemyHP"))
                PlayerPrefs.SetInt("EnemyHP", 10);
            return PlayerPrefs.GetInt("EnemyHP");
        }

        set => PlayerPrefs.SetInt("EnemyHP", value);

    }

    public static int CoinReward
    {
        get
        {
            if (!PlayerPrefs.HasKey("CoinReward"))
                PlayerPrefs.SetInt("CoinReward", 10);
            return PlayerPrefs.GetInt("CoinReward");
        }

        set => PlayerPrefs.SetInt("CoinReward", value);

    }

    public static int BasicDamage
    {
        get
        {
            if (!PlayerPrefs.HasKey("BasicDamage"))
                PlayerPrefs.SetInt("BasicDamage", 2);
            return PlayerPrefs.GetInt("BasicDamage");
        }

        set => PlayerPrefs.SetInt("BasicDamage", value);

    }
    public static float BasicShotDelay
    {
        get
        {
            if (!PlayerPrefs.HasKey("BasicShotDelay"))
                PlayerPrefs.SetFloat("BasicShotDelay", 0.5f);
            return PlayerPrefs.GetFloat("BasicShotDelay");
        }

        set => PlayerPrefs.SetFloat("BasicShotDelay", value);

    }

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
