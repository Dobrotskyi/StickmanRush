using UnityEngine;

public class DisableAfterGameStarts : MonoBehaviour
{
    private void OnEnable()
    {
        GameStarter.Start += DisableButton;
    }

    private void OnDisable()
    {
        GameStarter.Start -= DisableButton;
    }

    private void DisableButton() => gameObject.SetActive(false);
}
