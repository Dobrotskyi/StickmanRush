using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runningSpeed = 1f;
    private Animator _animator;
    private bool _isRunning = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isRunning)
            if (Input.GetMouseButtonDown(0))
                _isRunning = true;
    }

    private void FixedUpdate()
    {
        if (_isRunning)
        {
            transform.Translate(transform.forward * _runningSpeed * Time.deltaTime);
            _animator.SetBool("IsRunning", _isRunning);
        }
    }
}
