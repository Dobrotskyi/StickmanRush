using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action CollectedByPlayer;

    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, 30f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectedByPlayer?.Invoke();
            _animator.SetTrigger("Collected");
        }
    }
}
