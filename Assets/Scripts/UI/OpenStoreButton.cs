using UnityEngine;
using UnityEngine.UI;

public class OpenStoreButton : MonoBehaviour
{
    [SerializeField] private Sprite _storeSprite;
    [SerializeField] private Sprite _goBackSprite;
    [SerializeField] private Image _image;

    public void SwapIcon()
    {
        if (_image.sprite == _storeSprite)
            _image.sprite = _goBackSprite;
        else if (_image.sprite == _goBackSprite)
            _image.sprite = _storeSprite;
    }
}
