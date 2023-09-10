using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMenu : MonoBehaviour
{
    [SerializeField] private GameObject _goBackMenu;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void ShowOrHideMenu()
    {
        _goBackMenu.SetActive(!_goBackMenu.activeSelf);
        if (_goBackMenu.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
}
