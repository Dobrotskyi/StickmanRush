using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PopDownText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField;
    private Animator _animator;

    public void SetText(string text) => _textField.text = text;

    public void Init(Transform parent, string text)
    {
        PopDownText popDown = Instantiate(this, parent);
        if (int.TryParse(text, out int number))
            if (number > 0)
                text = text.Insert(0, "+");

        popDown._textField.text = text;
        popDown.transform.position = parent.position;
    }

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
