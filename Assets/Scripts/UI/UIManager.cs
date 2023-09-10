using EnemyMechanics;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _lostMenu;
    [SerializeField] private GameObject _wonMenu;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _inputSlider;
    [SerializeField] private GameObject _store;

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

    public void GameStarted()
    {
        _playButton.SetActive(false);
        _inputSlider.SetActive(true);
    }

    public void OpenOrCloseStore()
    {
        _store.SetActive(!_store.activeSelf);
    }
}
