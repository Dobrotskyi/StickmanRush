using EnemyMechanics;
using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _lostMenu;
    [SerializeField] private GameObject _wonMenu;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _inputSlider;

    private void OnEnable()
    {
        PlayerMovement.PlayerLost += ShowLostMenu;
        Boss.BossIsDead += ShowWinMenu;
        GameStarter.Instance.Start += GameStarted;
    }

    private void OnDisable()
    {
        PlayerMovement.PlayerLost -= ShowLostMenu;
        Boss.BossIsDead -= ShowWinMenu;
        GameStarter.Instance.Start -= GameStarted;
    }

    private void ShowLostMenu()
    {
        _lostMenu.SetActive(true);
    }

    private void ShowWinMenu()
    {
        _wonMenu.SetActive(true);
    }

    public void StartGameButtonPressed() => GameStarter.Instance.StartGame();

    public void GameStarted()
    {
        _playButton.SetActive(false);
        _inputSlider.SetActive(true);
    }
}
