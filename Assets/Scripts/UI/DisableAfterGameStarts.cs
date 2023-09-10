using UnityEngine;

public class DisableAfterGameStarts : MonoBehaviour
{
    private void OnEnable()
    {
        GameStarter.Instance.Start += DisableButton;
    }

    private void OnDisable()
    {
        GameStarter.Instance.Start -= DisableButton;
    }

    private void DisableButton() => gameObject.SetActive(false);
}
