using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBalanceSettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject _body;

    [SerializeField] private List<TMP_InputField> _fields = new();
    [SerializeField] private TextMeshProUGUI _buttonText;

    public void ShowSettings()
    {
        _body.SetActive(!_body.activeSelf);
        if (_body.activeSelf)
            _buttonText.text = "Close balance settings";
        else
            _buttonText.text = "Open balance settings";
    }

    public void ApplyChanges()
    {
        int i = 0;
        GameBalance.BasicShotDelay = float.Parse(_fields[i++].text);
        GameBalance.BasicDamage = int.Parse(_fields[i++].text);
        GameBalance.EnemySpawnFrequency = int.Parse(_fields[i++].text);
        GameBalance.BossHP = int.Parse(_fields[i++].text);
        GameBalance.EnemyHP = int.Parse(_fields[i++].text);
        GameBalance.CoinReward = int.Parse(_fields[i++].text);
        GameBalance.RewardForBoss = int.Parse(_fields[i++].text);
    }

    public void DiscardChanges()
    {
        DisplayInfo();
    }

    private void Awake()
    {
        DisplayInfo();
    }

    private void DisplayInfo()
    {
        int i = 0;
        _fields[i++].text = GameBalance.BasicShotDelay.ToString();
        _fields[i++].text = GameBalance.BasicDamage.ToString();
        _fields[i++].text = GameBalance.EnemySpawnFrequency.ToString();
        _fields[i++].text = GameBalance.BossHP.ToString();
        _fields[i++].text = GameBalance.EnemyHP.ToString();
        _fields[i++].text = GameBalance.CoinReward.ToString();
        _fields[i++].text = GameBalance.RewardForBoss.ToString();
    }
}
