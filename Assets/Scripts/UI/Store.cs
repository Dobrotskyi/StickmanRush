using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeDamageFieldPrice;
    [SerializeField] private TextMeshProUGUI _upgradeDamageFieldLevel;

    [SerializeField] private TextMeshProUGUI _upgradeFireRateFieldPrice;
    [SerializeField] private TextMeshProUGUI _upgradeFireRateFieldLevel;
    [SerializeField] private Button _upgradeFireRateButton;
    [SerializeField] private GameObject _maxLevelReached;
    [SerializeField] private GameObject _upgradeTextGroup;

    public void UpgradeDamage()
    {
        GameBalance.TryUpgradeDamage();
        UpdateDamageCostText();
    }

    public void UpgradeFireRate()
    {
        GameBalance.TryUpgradeFireRate();
        UpdateFireRateCostText();
    }

    private void OnEnable()
    {
        UpdateDamageCostText();
        UpdateFireRateCostText();
    }

    private void UpdateDamageCostText()
    {
        _upgradeDamageFieldPrice.text = GameBalance.PriceForDamageUpgrade.ToString();
        _upgradeDamageFieldLevel.text = GameBalance.CurrentDamageLevel.ToString();
    }

    private void UpdateFireRateCostText()
    {
        if (GameBalance.FireRateReachedMax())
        {
            _upgradeFireRateButton.interactable = false;
            _maxLevelReached.gameObject.SetActive(true);
            _upgradeTextGroup.SetActive(false);
        }
        else
        {
            _upgradeFireRateFieldPrice.text = GameBalance.PriceForFireRateUpgrade.ToString();
            _upgradeFireRateFieldLevel.text = GameBalance.CurrentFireRateLevel.ToString();
        }
    }
}
