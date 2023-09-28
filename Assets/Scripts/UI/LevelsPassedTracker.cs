using EnemyMechanics;
using TMPro;
using UnityEngine;

public class LevelsPassedTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amtText;
    private void DisplayPassedLevelsAmt()
    {
        _amtText.text = PlayerPrefs.GetInt("PassedLevelsCount").ToString();
    }

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("PassedLevelsCount"))
            PlayerPrefs.SetInt("PassedLevelsCount", 0);
        DisplayPassedLevelsAmt();
        Boss.BossIsDead += OnLevelPassed;
    }
    private void OnLevelPassed()
    {
        PlayerPrefs.SetInt("PassedLevelsCount", PlayerPrefs.GetInt("PassedLevelsCount") + 1);
    }

    private void OnDisable()
    {
        Boss.BossIsDead -= OnLevelPassed;
    }
}
