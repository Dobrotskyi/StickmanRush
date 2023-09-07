using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runningSpeed = 1f;
    [SerializeField] private float _sideSpeed = 0.5f;

    [SerializeField] private MySlider _movementSlider;

    private Animator _animator;
    private bool _isRunning;
    private bool _runningToTheSide;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isRunning)
            if (Input.GetMouseButtonDown(1))
                _isRunning = true;

        if (_movementSlider.IsHeld && _movementSlider.value != 0)
            _runningToTheSide = true;
        else
            _runningToTheSide = false;
    }

    private void FixedUpdate()
    {
        if (_isRunning)
            transform.Translate(transform.forward * _runningSpeed * Time.deltaTime);
        else
            return;

        if (!_runningToTheSide)
            _animator.SetBool("IsRunning", _isRunning);
        else
        {
            transform.Translate(transform.right * Time.deltaTime * _movementSlider.value);

            if (_movementSlider.value < 0)
            {//running right anim 
            }
            else if (_movementSlider.value > 0)
            {//running left anim
            }
        }
    }
}
