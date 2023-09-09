using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public event Action PlayerReadyForBoss;

    [SerializeField] private float _runningSpeed = 4f;
    [SerializeField] private float _sideRunningSpeed = 3f;
    [SerializeField] private PlayerInputSlider _movementSlider;

    private Animator _animator;
    private bool _isRunning;
    private bool _runningToTheSide;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //temporary
        if (!_isRunning)
            if (Input.GetMouseButtonDown(1))
                _isRunning = true;
        //temporary

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
        {
            ResetMovingToSidesAnimations();
            _animator.SetBool("IsRunning", _isRunning);
        }
        else
        {
            transform.Translate(transform.right * Time.deltaTime * _movementSlider.value * _sideRunningSpeed);

            if (_movementSlider.value < 0)
            {
                if (_animator.GetBool("ToTheRight"))
                    _animator.SetBool("ToTheRight", false);
                _animator.SetBool("ToTheLeft", true);
            }
            else if (_movementSlider.value > 0)
            {
                if (_animator.GetBool("ToTheLeft"))
                    _animator.SetBool("ToTheLeft", false);
                _animator.SetBool("ToTheRight", true);
            }
        }
    }

    private void ResetMovingToSidesAnimations()
    {
        if (_animator.GetBool("ToTheLeft"))
            _animator.SetBool("ToTheLeft", false);
        if (_animator.GetBool("ToTheRight"))
            _animator.SetBool("ToTheRight", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Die();
    }

    private void Die()
    {
        Debug.Log("You Lost");
    }
}
