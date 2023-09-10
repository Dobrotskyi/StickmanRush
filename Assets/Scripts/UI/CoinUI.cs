using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinAmountText;

    private void Awake()
    {
        UpdateUI();
        CoinTracker.AmtUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        CoinTracker.AmtUpdated -= UpdateUI;
    }

    private void UpdateUI() => _coinAmountText.text = CoinTracker.Instance.CoinAmt.ToString();

}
