using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinAmountText;
    [SerializeField] private PopDownText _popDown;
    private int _lastValue = -1;

    private void Awake()
    {
        UpdateUI();
        CoinTracker.AmtUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        CoinTracker.AmtUpdated -= UpdateUI;
    }

    private void UpdateUI()
    {
        if (_lastValue == -1)
            _lastValue = CoinTracker.Instance.CoinAmt;

        int newValue = CoinTracker.Instance.CoinAmt;
        _coinAmountText.text = newValue.ToString();
        if (_lastValue != newValue)
        {
            _popDown.Init(transform, (newValue - _lastValue).ToString());
            _lastValue = newValue;
        }
    }
}
