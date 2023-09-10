using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject _body;

    [SerializeField] private TextMeshProUGUI _upgradeDamageFieldPrice;
    [SerializeField] private TextMeshProUGUI _upgradeDamageFieldLevel;

    [SerializeField] private TextMeshProUGUI _upgradeFireRateFieldPrice;
    [SerializeField] private TextMeshProUGUI _upgradeFireRateFieldLevel;

    [SerializeField] private TextMeshProUGUI _upgradeDamageAmt;

    [SerializeField] private Button _upgradeFireRateButton;
    [SerializeField] private GameObject _maxLevelReached;
    [SerializeField] private GameObject _upgradeTextGroup;

    public void OpenOrCloseStore()
    {
        _body.SetActive(!_body.activeSelf);
    }

    public void UpgradeDamage()
    {
        GameBalance.TryUpgradeDamage();
        UpdateDamageText();
    }

    public void UpgradeFireRate()
    {
        GameBalance.TryUpgradeFireRate();
        UpdateFireRateText();
    }

    public void RestAllLevels()
    {
        PlayerPrefs.SetInt("FireRateLevel", 1);
        PlayerPrefs.SetInt("DamageLevel", 1);
        UpdateFireRateText();
        UpdateDamageText();
    }

    private void OnEnable()
    {
        UpdateDamageText();
        UpdateFireRateText();

        _upgradeDamageAmt.text += GameBalance.DamageUpgrade.ToString();
    }

    private void UpdateDamageText()
    {
        _upgradeDamageFieldPrice.text = GameBalance.PriceForDamageUpgrade.ToString();
        _upgradeDamageFieldLevel.text = GameBalance.CurrentDamageLevel.ToString();
    }

    private void UpdateFireRateText()
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
