using EnemyMechanics;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _lostMenu;
    [SerializeField] private GameObject _wonMenu;

    private void OnEnable()
    {
        PlayerMovement.PlayerLost += ShowLostMenu;
        Boss.BossIsDead += ShowWinMenu;
    }

    private void OnDisable()
    {
        PlayerMovement.PlayerLost -= ShowLostMenu;
        Boss.BossIsDead -= ShowWinMenu;
    }

    private void ShowLostMenu()
    {
        _lostMenu.SetActive(true);
    }

    private void ShowWinMenu()
    {
        _wonMenu.SetActive(true);
    }
}
