using EnemyMechanics;
using LevelQuads;
using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static event Action PlayerLost;
    public event Action PlayerReadyForBoss;
    public event Action PlayerMovingAtPosition;

    [SerializeField] private float _runningSpeed = 4f;
    [SerializeField] private float _sideRunningSpeed = 3f;
    [SerializeField] private PlayerInputSlider _movementSlider;

    private Animator _animator;
    private bool _runningToTheSide;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Enemy.PlayerGotKicked += Die;
        PlayerDeathFromFallingOff.FallOff += Die;
        GameStarter.Instance.Start += StartLevelRun;
    }

    private void OnDisable()
    {
        Enemy.PlayerGotKicked -= Die;
        PlayerDeathFromFallingOff.FallOff -= Die;
        GameStarter.Instance.Start -= StartLevelRun;
    }

    private void StartLevelRun() => StartCoroutine(LevelRun());

    private void Die()
    {
        StopAllCoroutines();
        _animator.SetBool("Dead", true);
        PlayerLost?.Invoke();
    }

    private void Update()
    {
        if (_movementSlider.IsHeld && _movementSlider.value != 0)
            _runningToTheSide = true;
        else
            _runningToTheSide = false;
    }

    private IEnumerator LevelRun()
    {
        while (true)
        {
            transform.Translate(transform.forward * _runningSpeed * Time.deltaTime);

            if (!_runningToTheSide)
            {
                ResetMovingToSidesAnimations();
                _animator.SetBool("IsRunning", true);
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
            yield return new WaitForFixedUpdate();
        }
    }

    private void ResetMovingToSidesAnimations()
    {
        if (_animator.GetBool("ToTheLeft"))
            _animator.SetBool("ToTheLeft", false);
        if (_animator.GetBool("ToTheRight"))
            _animator.SetBool("ToTheRight", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossQuad"))
        {
            StopAllCoroutines();
            StartCoroutine(MoveTowardsFiringPosition(other.GetComponent<BossQuad>().PlayerPosition));
        }
    }

    private IEnumerator MoveTowardsFiringPosition(Vector3 position)
    {
        PlayerMovingAtPosition?.Invoke();
        transform.rotation = Quaternion.LookRotation(position - transform.position);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        while (Vector3.Distance(position, transform.position) > 0.1f)
        {
            if (position.z < transform.position.z)
                break;
            transform.Translate((position - transform.position).normalized * _runningSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
        yield return AimAtBoss();
    }

    private IEnumerator AimAtBoss()
    {
        Transform bossTransform = GameObject.FindAnyObjectByType<Boss>().transform;
        Quaternion rotation;
        while (true)
        {
            rotation = Quaternion.LookRotation(bossTransform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 4f * Time.deltaTime);
            if (transform.rotation == rotation)
                break;
            yield return new WaitForFixedUpdate();
        }
        _animator.SetTrigger("ShootingBoss");
        PlayerReadyForBoss?.Invoke();
    }
}
