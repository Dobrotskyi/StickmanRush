using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _lostMenu;
    [SerializeField] private GameObject _wonMenu;

    private void OnEnable()
    {
        PlayerMovement.PlayerLost += ShowLostMenu;
    }

    private void OnDisable()
    {
        PlayerMovement.PlayerLost -= ShowLostMenu;
    }

    private void ShowLostMenu()
    {
        _lostMenu.SetActive(true);
    }
}
